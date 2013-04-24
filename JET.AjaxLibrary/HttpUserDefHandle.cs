
using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Reflection;
using System.Web.SessionState;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 自定义后缀名的处理,新增了继承session接口
    /// </summary>
    public class HttpUserDefHandle : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 程序集名
        /// </summary>
        public static Type AssemblyType;

        /// <summary>
        /// 程序集缓存
        /// </summary>
        static Dictionary<string, Type> RefKeyValue = new Dictionary<string, Type>(50);

        /// <summary>
        /// 获取一个值，该值指示其他请求是否可以使用 System.Web.IHttpHandler 实例。
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// http进程处理
        /// </summary>
        /// <param name="context">当前httpcontex对象</param>
        public void ProcessRequest(HttpContext context)
        {
            string[] classMethon = GetClassNameAndMethon(context);
            //获取类型缓存器
            Type type = GetTypeChche(classMethon[0]);
            //如果类型获取为空
            if (type == null)
            {
                //处理异常
                AjaxExceptionHelper.ExceptionProcess(context, new Exception((string.Format(Tip.TypeNotFound, classMethon[0]))));
            }
            else 
            {
                //调用方法执行器
                MethodExecutor.ProcessRequest(context, type, classMethon[1]);
            }

        }

        /// <summary>
        /// 获取类型缓存
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        private Type GetTypeChche(string sKey)
        {
            if (AssemblyType == null) 
            {
                return null;
            }
            if (RefKeyValue.ContainsKey(sKey))
            {
                return RefKeyValue[sKey];
            }
            else
            {
                string AssemblyName = AssemblyType.Assembly.ToString();
                Assembly assembly = Assembly.Load(AssemblyName);
                //忽略大小写查询程序集
                Type type = assembly.GetType(AssemblyType.Namespace + "." + sKey, false,true);
                //assembly.CreateInstance(AssemblyType.Namespace + "." + sKey, true);
                if (type == null) 
                {
                    AjaxExceptionHelper.ExceptionProcess(HttpContext.Current, new Exception(string.Format(Tip.TypeNotFound, AssemblyType.Namespace + "." + sKey)));
                }
                if (RefKeyValue.Count == 100) //缓存项达到100，清空
                {
                    RefKeyValue.Clear();
                }
                RefKeyValue.Add(sKey, type);
                return type;
            }
        }

        /// <summary>
        /// 获取类名和方法名
        /// </summary>
        /// <param name="context">当前http对象</param>
        /// <returns>返回类名+方法名</returns>
        private string[] GetClassNameAndMethon(HttpContext context) {
            string[] Segments = context.Request.Url.Segments;
            string fileName = Segments[Segments.Length - 1];
            string[] paras = fileName.Split('.');
            if (paras.Length != 3) {
                throw new ArgumentException("请求URL参数不正确！");
            }
            return paras;
        }
    }
}
