using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignupSystem.Services.CMS.Administration
{
    public class AdminSvc : IAdmin
    {
        protected DataContext _context;
        protected IEncode _enCode;

        public AdminSvc(DataContext context, IEncode encode)
        {
            _context = context;
            _enCode = encode;
        }

        //User
        public async Task<UserModel> GetUser(int id)
        {
            UserModel user = null;
            user = await _context.UserModels.FindAsync(id);
            return user;
        }


        //Khóa Học
        public async Task<CourseModel> GetCourse(int id)
        {
            CourseModel course = null;
            course = await _context.CourseModels.FindAsync(id);
            return course;
        }


        //Role
        public async Task<List<RoleModel>> GetRole()
        {
            var role = await _context.RoleModels.ToListAsync();
            return role;
        }
        public async Task<RoleModel> roleId(int id)
        {

            var role = await _context.RoleModels.FindAsync(id);
            return role;
        }
        public async Task<int> EditRole(RoleModel roleModel)
        {
            int ret = 0;
            try
            {
                RoleModel role = null;
                role = await roleId(roleModel.RoleId);
                role.RoleName = roleModel.RoleName;

                _context.Update(role);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> AddRole(RoleModel roleModel)
        {
            int ret = 0;
            try
            {
                _context.Add(roleModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }// thêm role

        public async Task<int> DeleteRole(int id)
        {
            int ret = 0;
            try
            {
                var role = await roleId(id);
                _context.Remove(role);
                await _context.SaveChangesAsync();
                ret = role.RoleId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }//xóa role


        ///Student
        public async Task<List<UserModel>> GetStudent()
        {
            var user = await _context.UserModels.Where(u => u.UserRole == 2).ToListAsync();
            return user;
        }

        public async Task<int> AddStudent(UserModel userModel)
        {
            int ret = 0;
            try
            {
                userModel.UserRole = 2;
                userModel.UserPassword = _enCode.Encode(userModel.UserPassword);   
                _context.Add(userModel);
                await _context.SaveChangesAsync();

                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditStudent(UserModel userModel)
        {
            
            int ret = 0;
            try
            {
                UserModel user = null;
                user = await GetUser(userModel.UserId);

                user.UserSurname = userModel.UserSurname;
                user.UserFisrtName = userModel.UserFisrtName;
                user.UserBirthday = userModel.UserBirthday;
                user.UserEmail = userModel.UserEmail;
                user.UserAddress = userModel.UserAddress;
                user.UserParentName = userModel.UserParentName;
                user.UserClass = userModel.UserClass;
                user.UserPhone = userModel.UserPhone;
                user.UserPassword = _enCode.Encode(userModel.UserPassword);
                
                _context.Update(user);
                await _context.SaveChangesAsync();

                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteStudent(int id)
        {
            int ret = 0;
            try
            {
                var user = await GetUser(id);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                ret = user.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //Tìm Kiếm học sinh sinh viên
        public async Task<List<UserModel>> GetStudent(UserModel userModel)
        {
            var user = await _context.UserModels.Where(e => e.UserRole == 2).Where(u => u.UserStudentCode == userModel.UserStudentCode ||
               u.UserFisrtName == userModel.UserFisrtName || u.UserPhone == userModel.UserPhone || u.UserEmail == userModel.UserEmail).ToListAsync();
            return user;
        }

        ///Teacher
        public async Task<List<UserModel>>  GetTeacher()
        {
            var user = await _context.UserModels.Where(u => u.UserRole == 1).ToListAsync();
            return user;
        }

        public async Task<int> AddTeacher(UserModel userModel)
        {
            int ret = 0;
            try
            {
                userModel.UserRole = 1;
                userModel.UserPassword = _enCode.Encode(userModel.UserPassword);
                _context.Add(userModel);
                await _context.SaveChangesAsync();

                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditTeacher(UserModel userModel)
        {

            int ret = 0;
            try
            {
                UserModel user = null;
                user = await GetUser(userModel.UserId);

                user.UserSurname = userModel.UserSurname;
                user.UserFisrtName = userModel.UserFisrtName;
                user.UserBirthday = userModel.UserBirthday;
                user.UserEmail = userModel.UserEmail;
                user.UserAddress = userModel.UserAddress;
                user.UserParentName = userModel.UserParentName;
                user.UserClass = userModel.UserClass;
                user.UserPhone = userModel.UserPhone;
                user.UserPassword = _enCode.Encode(userModel.UserPassword);
                user.UserMainSubject = userModel.UserMainSubject;
                user.UserParttimeSubject = userModel.UserParttimeSubject;

                _context.Update(user);
                await _context.SaveChangesAsync();

                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteTeacher(int id)
        {
            int ret = 0;
            try
            {
                var user = await GetUser(id);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                ret = user.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //Tìm Kiếm giáo viên
        //public async Task<List<UserModel>> GetTeacher(ViewLogin viewLogin)
        //{
        //    var user = await _context.UserModels.Where(u => u.UserTeacherCode == viewLogin.UserTeacherCode ||
        //       u.UserFisrtName == viewLogin.UserFisrtName || u.UserPhone == viewLogin.UserPhone || u.UserEmail == viewLogin.UserEmail).ToListAsync();
        //    return user;
        //}
        public async Task<List<UserModel>> GetTeacher(UserModel userModel)
        {
            var user = await _context.UserModels.Where(e => e.UserRole == 1).Where(u => u.UserTeacherCode == userModel.UserTeacherCode ||
               u.UserFisrtName == userModel.UserFisrtName || u.UserPhone == userModel.UserPhone || u.UserEmail == userModel.UserEmail).ToListAsync();
            return user;
        }

        //Khóa Học
        public async Task<List<CourseModel>> ListKhoaHoc()
        {
            var list = await _context.CourseModels.ToListAsync();
            return list;
        }

        public async Task<int> AddKhoaHoc(CourseModel courseModel)
        {
            int ret = 0;
            try
            {
               await _context.AddAsync(courseModel);
                await _context.SaveChangesAsync();

                ret = courseModel.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;

        }

        public async Task<int> EditKhoaHoc(CourseModel courseModel)
        {
            int ret = 0;
            try
            {
                CourseModel course = null;
                course = await GetCourse(courseModel.CourseId);

                course.CourseCode = courseModel.CourseCode;
                course.CourseName = courseModel.CourseName;
                course.CourseStartTime = courseModel.CourseStartTime;
                course.CourseEndTime = courseModel.CourseEndTime;

                _context.Update(course);
                await _context.SaveChangesAsync();
                ret = courseModel.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteKhoaHoc(int id)
        {
            int ret = 0;
            try
            {
                var course = await GetCourse(id);
                _context.Remove(course);
                await _context.SaveChangesAsync();
                ret = course.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //tìm kiếm khóa học

        //Department
        public async Task<List<DepartmentModel>> GetDepartment()
        {
            var department = await _context.DepartmentModels.ToListAsync();
            return department;
        }

        public async Task<List<DepartmentModel>> GetDepartmentId(DepartmentModel departmentModel)
        {
            var department = await _context.DepartmentModels.Where(d => d.DepartmentName == departmentModel.DepartmentName).ToListAsync();
            return department;
        }

        public async Task<DepartmentModel> GetDepartmentId(int id)
        {
            DepartmentModel department = null;
            department = await _context.DepartmentModels.FindAsync(id);
            return department;
        }

        public async Task<int> AddDepartment(DepartmentModel departmentModel)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(departmentModel);
                await _context.SaveChangesAsync();
                ret = departmentModel.DepartmentId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditDepartment(DepartmentModel departmentModel)
        {
            int ret = 0;
            try
            {
                DepartmentModel depart = null;
                depart = await GetDepartmentId(departmentModel.DepartmentId);

                depart.DepartmentName = departmentModel.DepartmentName;

                _context.Update(depart);
                await _context.SaveChangesAsync();
                ret = departmentModel.DepartmentId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteDepartment(int id)
        {
            int ret = 0;
            try
            {
                var depart = await GetDepartmentId(id);
                _context.Remove(depart);
                await _context.SaveChangesAsync();
                ret = depart.DepartmentId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //Subject (môn học)
        public async Task<List<SubjectModel>> GetSubject()
        {
            var subjects = await _context.SubjectModels.ToListAsync();
            return subjects;
        }

        public async Task<List<SubjectModel>> GetSubjectAll()
        {
            var subjects = await _context.SubjectModels.Include(s => s.courseModel).
                                    Include(s => s.departmentModel).ToListAsync();
            return subjects;
        }

        public async Task<List<SubjectModel>> GetSubjectId(SubjectModel subjectModel)
        {
            var subjects = await _context.SubjectModels.Where(s => s.SubjectName == subjectModel.SubjectName ||
                                                  s.SubjectCode == subjectModel.SubjectCode).ToListAsync();
            return subjects;
        }

        public async Task<SubjectModel> GetSubjectId(int id)
        {
            SubjectModel subject = null;
            subject = await _context.SubjectModels.FindAsync(id);
            return subject;
        }

        public async Task<int> AddSubject(SubjectModel subjectModel)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(subjectModel);
                await _context.SaveChangesAsync();
                ret = subjectModel.SubjectId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditSubject(SubjectModel subjectModel)
        {
            int ret = 0;
            try
            {
                SubjectModel subject = null;
                subject = await GetSubjectId(subjectModel.SubjectId);

                subject.SubjectName = subjectModel.SubjectName;
                subject.SubjectCode = subjectModel.SubjectCode;
                subject.SubjectCourse = subjectModel.SubjectCourse;
                subject.SubjectDepartment = subjectModel.SubjectDepartment;

                _context.Update(subject);
                await _context.SaveChangesAsync();
                ret = subjectModel.SubjectId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteSubject(int id)
        {
            int ret = 0;
            try
            {
                var subject = await GetSubjectId(id);
                _context.Remove(subject);
                await _context.SaveChangesAsync();
                ret = subject.SubjectId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        // Class (lớp học)
        public async Task<List<ClassModel>> GetLopHoc()
        {
            List<ClassModel> list = new List<ClassModel>();
            list = await _context.ClassModels.ToListAsync();
            return list;
        }

        public async Task<List<UserModel>> GetLopHocStudent(ClassModel classModel)
        {
            List<UserModel> listStudent = new List<UserModel>();

            listStudent = await _context.UserModels.Where(s => s.UserClass == classModel.ClassName).ToListAsync();
            return listStudent;
        }

        public async Task<List<ClassModel>> GetLopHocId(ClassModel classModel)
        {
            List<ClassModel> list = new List<ClassModel>();
            list = await _context.ClassModels.Where(c => c.ClassCode == classModel.ClassCode ||
                            c.ClassName == classModel.ClassName).ToListAsync();
            return list;
        }

        public async Task<ClassModel> GetLopHocId(int id)
        {
            var classModel = await _context.ClassModels.FindAsync(id);
            return classModel;
        }

        public async Task<int> AddLopHoc(ClassModel classModel)
        {
            int ret = 0;
            try
            {
                var courseName = await _context.CourseModels.FindAsync(classModel.ClassCourse);

                classModel.ClassCourseName = courseName.CourseName;

                await _context.AddAsync(classModel);
                await _context.SaveChangesAsync();
                ret = classModel.ClassId;
            }
            catch (Exception)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditLopHoc(ClassModel classModel)
        {
            int ret = 0;
            try
            {
                ClassModel classs = null;
                classs = await GetLopHocId(classModel.ClassId);

                classs.ClassName = classModel.ClassName;
                classs.ClassCode = classModel.ClassCode;
                classs.ClassSchoolYear = classModel.ClassSchoolYear;
                classs.ClassDescription = classModel.ClassDescription;
                classs.ClassQuantity = classModel.ClassQuantity;
                classs.ClassStatus = classModel.ClassStatus;
                classs.ClassTuition = classModel.ClassTuition;

                var courseName = await _context.CourseModels.FindAsync(classModel.ClassCourse);

                classs.ClassCourseName = courseName.CourseName;

                _context.Update(classs);
                await _context.SaveChangesAsync();
                ret = classModel.ClassId;
            }
            catch (Exception)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteLopHoc(int id)
        {
            int ret = 0;
            try
            {
                var classs = await GetLopHocId(id);
                _context.Remove(classs);
                await _context.SaveChangesAsync();
                ret = classs.ClassId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }


    }
}
