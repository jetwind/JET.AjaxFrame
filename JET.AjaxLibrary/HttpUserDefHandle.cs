using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Reflection;

namespace JET.AjaxLibrary
{
    /// <summary>
    /// 自定义后缀名的处理球
    /// </summary>
    public class HttpUserDefHandle:IHttpHandler
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
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            string[] classMethon = GetClassNameAndMethon(context);
            //获取类型缓存器
            Type type = GetTypeChche(classMethon[0]);
            if (type == null)
            {
                AjaxExceptionHelper.ExceptionProcess(context, new Exception((string.Format(Tip.TypeNotFound, classMethon[0]))));
            }
            else 
            {
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
            string AssemblyName = AssemblyType.Assembly.ToString();
            Assembly assembly = Assembly.Load(AssemblyName);
            if (RefKeyValue.ContainsKey(sKey))
            {
                return RefKeyValue[sKey];
            }
            else
            {
                Type type = assembly.GetType(AssemblyType.Namespace + "." + sKey, false,true);
                //assembly.CreateInstance(AssemblyType.Namespace + "." + sKey, true);
                if (type == null) 
                {
                    AjaxExceptionHelper.ExceptionProcess(HttpContext.Current, new Exception(string.Format(Tip.TypeNotFound, AssemblyType.Namespace + "." + sKey)));
                }
                if (RefKeyValue.Count == 100) //缓存项达到50，清空
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
            string url = context.Request.Url.ToString();
            string fileName = System.IO.Path.GetFileNameWithoutExtension(url);
            string[] paras = fileName.Split('.');
            if (paras.Length != 2) {
                throw new ArgumentException("请求URL参数不正确！");
            }
            return paras;
        }
    }
}
