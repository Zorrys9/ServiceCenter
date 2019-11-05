using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
namespace Logic.LogicModel
{
    public class StageLogic
    {

        public static Dictionary<int,string> GetStage()
        {
            Dictionary<int, string> StageList = new Dictionary<int, string>();
            var Stages = DbContext.db.Stages;
            foreach(var item in Stages)
            {
                StageList.Add(item.IdStage, item.Name);
            }
            return StageList;
        }

    }
}
