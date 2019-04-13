using SchoolManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoom(int roomId);
        IEnumerable<Room> GetRoomsByCourse(int courseId);
        IEnumerable<Room> GetRooms(Expression<Func<Room, bool>> where);
        void CreateRoom(Room room);
        void EditRoom(Room room);
        void DeleteRoom(Room room);
        void DeleteRoom(int roomId);
    }
}
