﻿using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        //Score Type (loại điểm)
        public async Task<List<ScoreTypeModel>> GetScoreType()
        {
            var scoreType = await _context.ScoreTypesModels.ToListAsync();
            return scoreType;
        }

        public async Task<ScoreTypeModel> GetScoreTypeId(int id)
        {
            ScoreTypeModel scoreType = null;
            scoreType = await _context.ScoreTypesModels.FindAsync(id);
            return scoreType;
        }

        public async Task<int> AddScoreType(ScoreTypeModel scoreTypeModel)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(scoreTypeModel);
                await _context.SaveChangesAsync();
                ret = scoreTypeModel.ScoreTypeId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditScoreType(ScoreTypeModel scoreTypeModel)
        {

            int ret = 0;
            try
            {
                ScoreTypeModel scoreType = null;
                scoreType = await GetScoreTypeId(scoreTypeModel.ScoreTypeId);

                scoreType.ScoreTypeName = scoreTypeModel.ScoreTypeName;
                scoreType.ScoreTypeCoefficient = scoreTypeModel.ScoreTypeCoefficient;

                _context.Update(scoreType);
                await _context.SaveChangesAsync();
                ret = scoreTypeModel.ScoreTypeId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteScoreType(int id)
        {
            int ret = 0;
            try
            {
                var scoreType = await GetScoreTypeId(id);
                _context.Remove(scoreType);
                await _context.SaveChangesAsync();
                ret = scoreType.ScoreTypeId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //Score điểm
        public async Task<List<ScoreModel>> GetScore()
        {
            var score = await _context.ScoreModels.ToListAsync();
            return score;
        }

        public async Task<List<ScoreModel>> GetScoreAll()
        {
            var score = await _context.ScoreModels.Include(s => s.subjectModel).
                                    Include(s => s.scoreTypeModel).ToListAsync();
            return score;
        }

        public async Task<List<ScoreModel>> GetScoreId(ScoreModel scoreModel)
        {
            var score = await _context.ScoreModels.Where(s => s.ScoreSubjectName == scoreModel.ScoreSubjectName).ToListAsync();
            return score;
        }

        public async Task<ScoreModel> GetScoreId(int id)
        {
            ScoreModel score = null;
            score = await _context.ScoreModels.FindAsync(id);
            return score;
        }

        public async Task<int> AddScore(ScoreModel scoreModel)
        {
            int ret = 0;
            try
            {
                var ScoreType = await _context.ScoreTypesModels.FindAsync(scoreModel.ScoreType);
                var ScoreSubject = await _context.SubjectModels.FindAsync(scoreModel.ScoreSubjectId);
                var ScoreCourse = await _context.CourseModels.FindAsync(ScoreSubject.SubjectCourse);

                scoreModel.ScoreTypeName = ScoreType.ScoreTypeName;
                scoreModel.ScoreSubjectName = ScoreSubject.SubjectName;
                scoreModel.ScoreCourse = ScoreCourse.CourseName;

                await _context.AddAsync(scoreModel);
                await _context.SaveChangesAsync();
                ret = scoreModel.ScoreId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditScore(ScoreModel scoreModel)
        {
            int ret = 0;
            try
            {
                ScoreModel score = null;
                score = await GetScoreId(scoreModel.ScoreId);

                var ScoreType = await _context.ScoreTypesModels.FindAsync(scoreModel.ScoreType);
                var ScoreSubject = await _context.SubjectModels.FindAsync(scoreModel.ScoreSubjectId);
                var ScoreCourse = await _context.CourseModels.FindAsync(ScoreSubject.SubjectCourse);

                score.ScoreTypeName = ScoreType.ScoreTypeName;
                score.ScoreSubjectName = ScoreSubject.SubjectName;
                score.ScoreCourse = ScoreCourse.CourseName;

                _context.Update(score);
                await _context.SaveChangesAsync();
                ret = scoreModel.ScoreId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteScore(int id)
        {
            int ret = 0;
            try
            {
                var score = await GetScoreId(id);
                _context.Remove(score);
                await _context.SaveChangesAsync();
                ret = score.ScoreId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //Receipts học phí
        public async Task<List<ReceiptsModel>> GetReceipts()
        {
            var list = await _context.ReceiptsModels.ToListAsync();
            return list;
        }
        public async Task<int> AddReceipts(ReceiptsModel receiptsModel)
        {
            int ret = 0;
            try
            {
                var student = await _context.UserModels.FindAsync(receiptsModel.ReceiptsStudentId);
                var classs = await _context.ClassModels.FindAsync(student.UserClass);
                var teacher = await _context.ScheduleModels.Where(s => s.ScheduleClassId == classs.ClassId).FirstOrDefaultAsync();

                receiptsModel.ReceiptsTraining = student.UserFisrtName;
                receiptsModel.ReceiptsClassName = classs.ClassName;
                receiptsModel.ReceiptsFee = classs.ClassTuition;
                receiptsModel.ReceiptsRateFee = classs.ClassTuition;
                receiptsModel.ReceiptsPayableFee = receiptsModel.ReceiptsFee + receiptsModel.ReceiptsSurcharge;

                if (teacher != null)
                {
                    TurnoverModel turnoverModel = new TurnoverModel();
                    turnoverModel.TurnoverStudentCode = student.UserStudentCode;
                    turnoverModel.TurnoverStudentName = student.UserFisrtName;
                    turnoverModel.TurnoverStudentClass = classs.ClassName;
                    turnoverModel.TurnoverTeacher = teacher.ScheduleTeacherName;
                    turnoverModel.TurnoverStudyDate = Convert.ToString(teacher.ScheduleOn);
                    turnoverModel.TurnoverStartDate = teacher.ScheduleStartDate;
                    turnoverModel.TurnoverEndDate = teacher.ScheduleEndDate;
                    turnoverModel.TurnoverTuition = classs.ClassTuition;

                    await _context.AddAsync(turnoverModel);
                    await _context.SaveChangesAsync();
                }
                await _context.AddAsync(receiptsModel);
                await _context.SaveChangesAsync();
                ret = receiptsModel.ReceiptsId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //Schedule lịch dạy
        public async Task<List<ScheduleModel>> GetSchedule()
        {
            var list = await _context.ScheduleModels.ToListAsync();
            return list;
        }

        public async Task<List<ScheduleModel>> ScheduleId(ScheduleModel scheduleModel)
        {
            List<ScheduleModel> list = new List<ScheduleModel>();
            list = await _context.ScheduleModels.Where(l => l.ScheduleTeacherName == scheduleModel.ScheduleTeacherName ||
                            l.ScheduleSubjectName == scheduleModel.ScheduleSubjectName).ToListAsync();
            return list;
        }
        public async Task<ScheduleModel> ScheduleId(int id)
        {
            var list = await _context.ScheduleModels.FindAsync(id);
            return list;
        }
        public async Task<int> AddSchedule(ScheduleModel scheduleModel)
        {
            int ret = 0;
            try
            {
                var subject = await _context.SubjectModels.FindAsync(scheduleModel.ScheduleClassId);
                var classs = await _context.ClassModels.FindAsync(scheduleModel.ScheduleClassId);
                var teacher = await _context.UserModels.FindAsync(scheduleModel.ScheduleUser);

                scheduleModel.ScheduleTeacherCode = teacher.UserTeacherCode;
                scheduleModel.ScheduleTeacherName = teacher.UserFisrtName;
                scheduleModel.ScheduleClassName = classs.ClassName;
                //scheduleModel.ScheduleSubjectName = subject.SubjectName;


                await _context.AddAsync(scheduleModel);
                await _context.SaveChangesAsync();
                ret = scheduleModel.ScheduleId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<bool> EditSchedule(ScheduleModel scheduleModel)
        {

            //int ret = 0;
            //try
            //{
            //    ScheduleModel schedule = null;
            //    schedule = await ScheduleId(scheduleModel.ScheduleId);

            //    var subject = await _context.SubjectModels.FindAsync(scheduleModel.ScheduleClassId);
            //    var classs = await _context.ClassModels.FindAsync(scheduleModel.ScheduleClassId);
            //    var teacher = await _context.UserModels.FindAsync(scheduleModel.ScheduleUser);


            //    schedule.ScheduleTeacherCode = teacher.UserTeacherCode;
            //    schedule.ScheduleTeacherName = teacher.UserFisrtName;
            //    schedule.ScheduleClassName = classs.ClassName;

            //    //schedule.ScheduleSubjectName = subject.SubjectName;
            //    schedule.ScheduleRoom = scheduleModel.ScheduleRoom;
            //    schedule.ScheduleTime = scheduleModel.ScheduleTime;
            //    schedule.ScheduleOn = scheduleModel.ScheduleOn;
            //    schedule.ScheduleStartDate = scheduleModel.ScheduleStartDate;
            //    schedule.ScheduleEndDate = scheduleModel.ScheduleEndDate;
            //    schedule.Schedule = scheduleModel.Schedule;

            //    _context.Update(schedule);
            //    await _context.SaveChangesAsync();
            //    ret = scheduleModel.ScheduleId;
            //}
            //catch (Exception ex)
            //{
            //    ret = 0;
            //}
            //return ret;

            _context.Update(scheduleModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> DeleteSchedule(int id)
        {
            int ret = 0;
            try
            {
                var schedule = await ScheduleId(id);
                _context.Remove(schedule);
                await _context.SaveChangesAsync();
                ret = schedule.ScheduleId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //ngày nghỉ
        public async Task<List<ScheduleHoliday>> GetScheduleHoliday()
        {
            var ScheduleHoliday = await _context.ScheduleHolidays.ToListAsync();
            return ScheduleHoliday;
        }

        public async Task<List<ScheduleHoliday>> ScheduleHolidayId(ScheduleHoliday scheduleHoliday)
        {
            var schedule = await _context.ScheduleHolidays.Where(s => s.ScheduleHolidayName == scheduleHoliday.ScheduleHolidayName ||
                                            s.ScheduleHolidayReason == scheduleHoliday.ScheduleHolidayReason).ToListAsync();
            return schedule;
        }

        public async Task<ScheduleHoliday> ScheduleHolidayId(int id)
        {
            ScheduleHoliday scheduleHoliday = null;
            scheduleHoliday = await _context.ScheduleHolidays.FindAsync(id);
            return scheduleHoliday;
        }

        public async Task<int> AddScheduleHoliday(ScheduleHoliday scheduleHoliday)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(scheduleHoliday);
                await _context.SaveChangesAsync();
                ret = scheduleHoliday.ScheduleHolidayId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<bool> EditScheduleHoliday(ScheduleHoliday scheduleHoliday)
        {

            _context.Update(scheduleHoliday);
            await _context.SaveChangesAsync();
            return true;
            //int ret = 0;
            //try
            //{
            //    ScheduleHoliday schedule = null;
            //    schedule = await ScheduleHolidayId(scheduleHoliday.ScheduleHolidayId);

            //    schedule.ScheduleHolidayName = scheduleHoliday.ScheduleHolidayName;
            //    schedule.ScheduleHolidayReason = scheduleHoliday.ScheduleHolidayReason;
            //    schedule.ScheduleHolidayStartDate = scheduleHoliday.ScheduleHolidayStartDate;
            //    schedule.ScheduleHolidayEndDate = scheduleHoliday.ScheduleHolidayEndDate;

            //    _context.Update(schedule);
            //    await _context.SaveChangesAsync();
            //    ret = schedule.ScheduleHolidayId;
            //}
            //catch (Exception ex)
            //{
            //    ret = 0;
            //}
            //return ret;
        }

        public async Task<int> DeleteScheduleHoliday(int id)
        {
            int ret = 0;
            try
            {
                var scheduleHoliday = await ScheduleHolidayId(id);
                _context.Remove(scheduleHoliday);
                await _context.SaveChangesAsync();
                ret = scheduleHoliday.ScheduleHolidayId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //


    }
}
