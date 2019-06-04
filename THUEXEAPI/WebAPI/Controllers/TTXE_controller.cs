using EF.Model;
using EF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/TTXE")]
    public class TTXE_controller : ApiController
    {
        TTXE_service ttxe_sv = new TTXE_service();

        [Route("GetTTXE")]
        [HttpGet]
        public IHttpActionResult GetTTXE()
        {
            var data = ttxe_sv.GetTTXE();
            var eventList = (from e in data
                             select new
                             {
                                 TTX_BSX = e.TTX_BSX,
                                 LX_ID = e.LX_ID,
                                 HSX_ID = e.HSX_ID,
                                 DONGIA = e.DONGIA,
                                 TTX_TRANGTHAI = e.TTX_TRANGTHAI

                             }).ToList();
            return Ok(eventList);
        }

        [Route("AddTTXE")]
        [HttpPost]
        public IHttpActionResult AddTTXE(TTXE entity)
        {
            ttxe_sv.Add(entity);
            return Ok("thêm thành công");
        }

        [Route("DeleteTTXE")]
        [HttpDelete]
        public IHttpActionResult DeleteTTXE(string id)
        {
            ttxe_sv.Delete(id);
            return Ok("xóa thành công");
        }

        [Route("UpdateTTXE")]
        [HttpPost]
        public IHttpActionResult UpdateTTXE(TTXE entity)
        {
            ttxe_sv.Update(entity.TTX_BSX,entity.DONGIA);
            return Ok("cập nhật thành công");
        }

        [Route("FindTTXE")]
        [HttpGet]
        public IHttpActionResult FindTTXE(string bsx)
        {
            var data=ttxe_sv.Find(bsx);
            return Ok(data);
        }


    }
}
