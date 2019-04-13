using SchoolManagementSystem.Data.Infrastructure.Interfaces;
using SchoolManagementSystem.Data.Repository.Interfaces;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RoomService(ICourseRepository courseRepository, IRoomRepository roomRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }
        public void CreateRoom(Room room)
        {
            _roomRepository.Add(room);
            SaveRoom();
        }

        public void DeleteRoom(Room room)
        {
            _roomRepository.Delete(room);
            SaveRoom();
        }

        public void DeleteRoom(int roomId)
        {
            var room = _roomRepository.GetById(roomId);
            if (room!=null)
            {
                _roomRepository.Delete(room);
                SaveRoom();
            }
        }

        public void EditRoom(Room room)
        {
            _roomRepository.Update(room);
            SaveRoom();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _roomRepository.GetAll();
        }

        public Room GetRoom(int roomId)
        {
            return _roomRepository.GetById(roomId);
        }

        public IEnumerable<Room> GetRooms(Expression<Func<Room, bool>> where)
        {
            return _roomRepository.GetMany(where);
        }

        public IEnumerable<Room> GetRoomsByCourse(int courseId)
        {
            var course = _courseRepository.GetById(courseId);
            if (course!=null)
            {
                return _roomRepository.GetMany(r => r.Courses.Contains(course));
            }
            return null;
        }
        private void SaveRoom()
        {
            _unitOfWork.Commit();
        }
    }
}
