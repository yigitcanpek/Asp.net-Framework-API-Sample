using DAL;
using Project.API.v.Attributes;
using Project.API.v.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Project.API.v.Controllers
{
    [ApiException]
    [Authorize]
    
    public class languagesController : ApiController
    {

            

            DataAcssesLayer dataAcssesLayer = new DataAcssesLayer();

            [ResponseType(typeof(IEnumerable<Table_1>))]
            [APIAuthorize(Roles = "a")]
            public IHttpActionResult Get()
            {
                IEnumerable<Table_1> languages = dataAcssesLayer.getAllLanguages();
                return Ok(languages);
                //return Request.CreateResponse(HttpStatusCode.OK,languages);
            }
            [APIAuthorize(Roles = "u")]
            public IHttpActionResult Get(int id)
            {
            
            
                Table_1 language = dataAcssesLayer.GetLanguageByID(id);
                if (language == null)
                {
                    return NotFound();
                    //return Request.CreateResponse(HttpStatusCode.NotFound,"Böyle Bir Kayıt Bulunamadı");
                }
                return Ok(language);
                //return  Request.CreateResponse(HttpStatusCode.OK,language);
            }



        /* 
        [HttpGet]
           public IHttpActionResult DilleriGetir(int id)
        {
        Table_1 language = dataAcssesLayer.GetLanguageByID(id);
        if (language == null)
        {
            return NotFound();
            //return Request.CreateResponse(HttpStatusCode.NotFound,"Böyle Bir Kayıt Bulunamadı");
        }
            return Ok(language);
            //return  Request.CreateResponse(HttpStatusCode.OK,language);
        }



         */




            
            public IHttpActionResult Post(Table_1 language)
            { 
            Table_1 createdlanguage =  dataAcssesLayer.CreateLanguage(language);
            if (ModelState.IsValid)
            {
                return CreatedAtRoute("DefaultApi",new {id = createdlanguage.ID },createdlanguage);
                //return Request.CreateResponse(HttpStatusCode.Created, language);
                
            }
            return BadRequest(ModelState);
            //return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ModelState);
            }
            
            public IHttpActionResult Put(int id, Table_1 language)
            {
            if ( dataAcssesLayer.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
                //return Request.CreateResponse(HttpStatusCode.NotFound, "kayıt bulunamadı");
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
                //return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                return Ok(dataAcssesLayer.UpdateLanguage(id, language));
                //return Request.CreateResponse(HttpStatusCode.OK,dataAcssesLayer.UpdateLanguage(id,language) );
            }

        }
           
            public IHttpActionResult Delete(int id)
            {
            if (dataAcssesLayer.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "kayıt bulunamadı");
            }
            else
            {
                dataAcssesLayer.DeleteLanguage(id);
                //return Ok();
                return StatusCode(HttpStatusCode.NoContent);
                //return Request.CreateResponse(HttpStatusCode.NoContent, "silme işlemi başarıyla yapıldı");
            }
            
            }
        }
    
}
