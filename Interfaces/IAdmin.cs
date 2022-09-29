using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignupSystem.Interfaces
{
    public interface IAdmin 
    {
        //role
        Task<List<RoleModel>> GetRole();
        Task<RoleModel> roleId(int id);
        Task<int> EditRole(RoleModel roleModel);
        Task<int> AddRole(RoleModel roleModel);
        Task<int> DeleteRole(int id);

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

        //Khóa Học
        Task<List<CourseModel>> ListKhoaHoc();
        Task<int> AddKhoaHoc(CourseModel courseModel);
        Task<int> EditKhoaHoc(CourseModel courseModel);
        Task<int> DeleteKhoaHoc(int id);
        //tìm kiếm khóa học


        //Department
        Task<List<DepartmentModel>> GetDepartment();
        Task<List<DepartmentModel>> GetDepartmentId(DepartmentModel departmentModel);
        Task<DepartmentModel> GetDepartmentId(int id);
        Task<int> AddDepartment(DepartmentModel departmentModel);
        Task<int> EditDepartment(DepartmentModel departmentModel);
        Task<int> DeleteDepartment(int id);

        //Subject (môn học)
        Task<List<SubjectModel>> GetSubject();
        Task<List<SubjectModel>> GetSubjectAll();
        Task<List<SubjectModel>> GetSubjectId(SubjectModel subjectModel);
        Task<SubjectModel> GetSubjectId(int id);
        Task<int> AddSubject(SubjectModel subjectModel);
        Task<int> EditSubject(SubjectModel subjectModel);
        Task<int> DeleteSubject(int id);

        // Class (lớp học)
        Task<List<ClassModel>> GetLopHoc();
        Task<List<UserModel>> GetLopHocStudent(ClassModel classModel);
        Task<List<ClassModel>> GetLopHocId(ClassModel classModel);
        Task<ClassModel> GetLopHocId(int id);
        Task<int> AddLopHoc(ClassModel classModel);
        Task<int> EditLopHoc(ClassModel classModel);
        Task<int> DeleteLopHoc(int id);
    }
}
