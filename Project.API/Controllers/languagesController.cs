using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.API.Controllers
{
    public class languagesController : Controller
    {
        DataAcssesLayer dataAcssesLayer = new DataAcssesLayer();
        public IEnumerable<Table_1> Get()
        {
            return dataAcssesLayer.getAllLanguages();
        }
        public Table_1 Get(int id)
        {
            return dataAcssesLayer.GetLanguageByID(id);
        }
        public Table_1 Post(Table_1 language)
        {
            return dataAcssesLayer.CreateLanguage(language);
        }
        public Table_1 Put(int id, Table_1 language)
        {
            return dataAcssesLayer.UpdateLanguage(id, language);
        }
        public void Delete(int id)
        {
            dataAcssesLayer.DeleteLanguage(id);
        }
    }
}