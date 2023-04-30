using NotSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NotSistemi.Controllers
{
    public class HomeApiNotlarController : ApiController
    {
        public IEnumerable<Notlar> Get()
        {
            MvcContext mvcContext = new MvcContext();
            List<Notlar> notlar = mvcContext.Notlar.ToList();
            return notlar;
        }

        public HttpResponseMessage Post(Notlar notlar)
        {
            try
            {
                MvcContext mvcContext = new MvcContext();
                mvcContext.Notlar.Add(notlar);
                if (mvcContext.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, notlar.id + " " + notlar.matematik + " adlı kullanıcı eklendi.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, notlar.id + " " +notlar.matematik + " adlı kullanıcı eklenemedi.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        public HttpResponseMessage Put(Notlar notlar)
        {

            try
            {
                MvcContext mvcContext = new MvcContext();
                Notlar k = mvcContext.Notlar.Where(x => x.id == notlar.id).SingleOrDefault();
                if (k == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "id : " + notlar.id);
                }

                k.id = notlar.id;
                k.matematik = notlar.matematik;


                if (mvcContext.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, " Öğrenci bilgileri düzenlendi.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Öğrenci bilgileri düzenlenemedi.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Delete(int id)
        {

            try
            {
                MvcContext mvcContext = new MvcContext();
                Notlar a = mvcContext.Notlar.Where(x => x.id == id).SingleOrDefault();
                if (a == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "id : " + id);
                }

               mvcContext.Notlar.Remove(a);

                if (mvcContext.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Öğrenci silindi.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Öğrenci silinemedi.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }















    }
}
