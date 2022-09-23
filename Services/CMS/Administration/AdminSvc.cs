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

    }
}
