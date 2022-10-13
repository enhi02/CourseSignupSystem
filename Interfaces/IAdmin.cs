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


        //Score Type
        Task<List<ScoreTypeModel>> GetScoreType();
        Task<ScoreTypeModel> GetScoreTypeId(int id);
        Task<int> AddScoreType(ScoreTypeModel scoreTypeModel);
        Task<int> EditScoreType(ScoreTypeModel scoreTypeModel);
        Task<int> DeleteScoreType(int id);

        //Score
        Task<int> AddScore(ScoreModel scoreModel);
        Task<List<ScoreModel>> GetScore();
        Task<List<ScoreModel>> GetScoreAll();
        Task<List<ScoreModel>> GetScoreId(ScoreModel scoreModel);
        Task<int> EditScore(ScoreModel scoreModel);
        Task<int> DeleteScore(int id);

        //Receipts học phí
        Task<List<ReceiptsModel>> GetReceipts();
        Task<int> AddReceipts(ReceiptsModel receiptsModel);

        //Schedule lịch dạy
        Task<List<ScheduleModel>> GetSchedule();
        Task<List<ScheduleModel>> ScheduleId(ScheduleModel scheduleModel);
        Task<ScheduleModel> ScheduleId(int id);
        Task<int> AddSchedule(ScheduleModel scheduleModel);
        Task<bool> EditSchedule(ScheduleModel scheduleModel);
        Task<int> DeleteSchedule(int id);

        //ngày nghỉ
        Task<List<ScheduleHoliday>> GetScheduleHoliday();
        Task<List<ScheduleHoliday>> ScheduleHolidayId(ScheduleHoliday scheduleHoliday);
        Task<ScheduleHoliday> ScheduleHolidayId(int id);
        Task<int> AddScheduleHoliday(ScheduleHoliday scheduleHoliday);
        Task<bool> EditScheduleHoliday(ScheduleHoliday scheduleHoliday);
        Task<int> DeleteScheduleHoliday(int id);
        //

    }
}
