using System.Web;
using GoSearcher.Business.Models;

namespace GoSearcher
{
    public class SkinDataConfig
    {
        public static void RegisterData()
        {
            string[] paths = new string[] {
                "~/App_Data/sticker-capsule.csv",
                "~/App_Data/sticker-capsule-2.csv",
                "~/App_Data/community-sticker-capsule-1.csv",
                "~/App_Data/ems-katowice-2014-legends.csv",
                "~/App_Data/ems-katowice-2014-challengers.csv"
            };

            foreach (var path in paths)
            {
                string absolutePath = HttpContext.Current.Server.MapPath(path);
                SkinDetailCache.Current.LoadFile(absolutePath);
            }

        }
    }
}