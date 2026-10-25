using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sarah10415_MVC.Models;

namespace Sarah10415_MVC.Controllers
{
    public class RoomController : Controller
    {
        SarahDbContext myDB = new SarahDbContext();
        public ActionResult Index()
        {
            List<Room> roomLst = new List<Room>();
            roomLst = (from room in myDB.rooms
                         select room).ToList();
            
            return View(roomLst);
        }

        public ActionResult GetDetails(int id)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == id
                   select room).FirstOrDefault();
           
            return View("RoomDetails",obj);
        }

        [HttpGet]
        public ActionResult InsertRoom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertRoom(Room room)
        {
            myDB.rooms.Add(room);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteRoom(int Id)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == Id
                   select room).FirstOrDefault();

            myDB.rooms.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateRoom(int Id)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == Id
                   select room).FirstOrDefault();

            obj.roomName = "New Room Name";
            myDB.SaveChanges();

            return View("Index");
        }


        //public ActionResult InsertRoom( )
        //{

        //    Room obj = new Room();
        //    obj.isAvailable = true;
        //    obj.location = "Buiding 3";
        //    obj.roomSize = 40;
        //    obj.roomName = "A120";

        //    myDB.rooms.Add(obj);
        //    myDB.SaveChanges();

        //    return RedirectToAction ("Index");
        //}

    }
}