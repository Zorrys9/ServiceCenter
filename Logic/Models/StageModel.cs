using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.EntityModels;
namespace Logic.Models
{
    public class StageModel
    {
        public int IdStage { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public static implicit operator StageModel(StagesEntityModel stage)
        {
            return new StageModel
            {
                IdStage = stage.IdStage,
                Name = stage.Name
            };
        }
    }
}
