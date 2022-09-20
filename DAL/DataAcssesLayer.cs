using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAcssesLayer:BaseDAL
    {
        
        public IEnumerable<Table_1> getAllLanguages()
        {
            return db.Table_1;
        }
        public Table_1 GetLanguageByID(int id)
        {
            return db.Table_1.Find(id);
        }
        public Table_1 CreateLanguage(Table_1 language)
        {
            db.Table_1.Add(language);
            db.SaveChanges();
            return language;
        }
        public Table_1 UpdateLanguage(int id, Table_1 language)
        {
            db.Entry(language).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return language;
        }
        public void DeleteLanguage(int id)
        {
            db.Table_1.Remove(db.Table_1.Find(id));
            db.SaveChanges();
        }
        public bool IsThereAnyLanguage (int id)
        {
            
            return db.Table_1.Any(x => x.ID == id);
        }
      
    }
}
