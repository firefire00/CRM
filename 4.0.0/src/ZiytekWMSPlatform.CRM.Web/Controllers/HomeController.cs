using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace ZiytekWMSPlatform.CRM.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : CRMControllerBase
    {
        private readonly ICapPublisher _capPublisher;

        /// <summary>
        /// 
        /// </summary>
        public HomeController(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        /// <summary>
        /// Ϊ�˷�ֹRabbitMQ����ʧ�ܣ��ڴ˷���һ�������Ѷ���
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            _capPublisher.Publish("CRMCapTest", "123");
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [CapSubscribe("CRMCapTest")]
        public ActionResult Done(string message) => Ok(message);
    }
}