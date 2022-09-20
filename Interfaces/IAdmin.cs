using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignupSystem.Interfaces
{
    public interface IAdmin 
    {
        //Student
        Task<int> AddStudent(UserModel userModel);
        Task<List<UserModel>> GetStudent();
        Task<int> EditStudent(UserModel userModel);
        Task<int> DeleteStudent(int id);
        //tìm kiếm học sinh sinh viên
        Task<List<UserModel>> GetStudent(UserModel userModel);

        //Teacher
        Task<int> AddTeacher(UserModel userModel);
        Task<List<UserModel>> GetTeacher();
        Task<int> EditTeacher(UserModel userModel);
        Task<int> DeleteTeacher(int id);
        //tìm kiếm giáo viên
        Task<List<UserModel>> GetTeacher(UserModel userModel);
    }
}
