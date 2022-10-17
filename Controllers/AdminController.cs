using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignupSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _adminSvc;

        public AdminController(IAdmin adminSvc)
        {
            _adminSvc = adminSvc;
        }

        //role
        [HttpGet]
        [Route("GetRole")]
        public async Task<ActionResult<IEnumerable<RoleModel>>> GetRole()
        {
            var role = await _adminSvc.GetRole();
            return role;
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult<int>> AddRole(RoleModel roleModel)
        {
            try
            {
                var id = await _adminSvc.AddRole(roleModel);
                roleModel.RoleId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditRole")]
        public async Task<ActionResult<int>> EditRole(RoleModel roleModel)
        {
            try
            {
                var id = await _adminSvc.EditRole(roleModel);
                roleModel.RoleId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public async Task<ActionResult<int>> DeleteRole(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteRole(id);

            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        ///student
        [HttpPost]
        [Route("AddStudent")]
        public async Task<ActionResult<int>> AddStudent(UserModel userModel)
        {
            try
            {
                await _adminSvc.AddStudent(userModel);
            }
            catch(Exception ex)
            {

            }
            return Ok(1);
        }

        [HttpGet]
        [Route("ListStudent")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetStudent()
        {
            var user = await _adminSvc.GetStudent();
            return user;
        }

        [HttpPost]
        [Route("EditStudent")]
        public async Task<ActionResult<int>> EditStudent( UserModel userModel)
        {
            try
            {
                await _adminSvc.EditStudent(userModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(2);
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<ActionResult<int>> DeleteStudent(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteStudent(id);

            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        //tìm kiếm học sinh sinh viên
        [HttpGet]
        [Route("StudentId")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetStudent(UserModel userModel)
        {
            var getalluser = await _adminSvc.GetStudent(userModel);
            return getalluser;
        }


        //Teacher
        [HttpPost]
        [Route("AddTeacher")]
        public async Task<ActionResult<int>> AddTeacher(UserModel userModel)
        {
            try
            {
                await _adminSvc.AddTeacher(userModel);
            }
            catch (Exception ex)
            {

            }
            return Ok(1);
        }

        [HttpGet]
        [Route("ListTeacher")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetTeacher()
        {
            var user = await _adminSvc.GetTeacher();
            return user;
        }

        [HttpPost]
        [Route("EditTeacher")]
        public async Task<ActionResult<int>> EditTeacher(UserModel userModel)
        {
            try
            {
                await _adminSvc.EditTeacher(userModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteTeacher/{id}")]
        public async Task<ActionResult<int>> DeleteTeacher(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteStudent(id);

            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        //Tìm kiếm giáo viên
        [HttpGet]
        [Route("TeacherId")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetTeacher(UserModel userModel)
        {
            var getalluser = await _adminSvc.GetTeacher(userModel);
            return getalluser;
        }

        //Khóa Học
        [HttpGet]
        [Route("ListKhoaHoc")]
        public async Task<ActionResult<IEnumerable<CourseModel>>> ListKhoaHoc()
        {
            var course = await _adminSvc.ListKhoaHoc();
            return course;
        }

        [HttpPost]
        [Route("AddKhoaHoc")]
        public async Task<ActionResult<int>> AddKhoaHoc(CourseModel courseModel)
        {
            try
            {
                var id = await _adminSvc.AddKhoaHoc(courseModel);
                courseModel.CourseId = id;
            }
            catch (Exception ex)
            {
                
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditKhoaHoc")]
        public async Task<ActionResult<int>> EditKhoaHoc(CourseModel courseModel)
        {
            try
            {
                await _adminSvc.EditKhoaHoc(courseModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteKhoaHoc/{id}")]
        public async Task<ActionResult<int>> DeleteKhoaHoc(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteKhoaHoc(id);

            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        //tìm kiếm khóa học



        //Department
        [HttpGet]
        [Route("ListDepartment")]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> ListAllDepartment()
        {
            var list = await _adminSvc.GetDepartment();
            return list;
        }

        [HttpGet]
        [Route("DepartmentId")]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartmentId(DepartmentModel department)
        {
            var list = await _adminSvc.GetDepartmentId(department);
            return list;
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<ActionResult<int>> AddDepartment(DepartmentModel department)
        {
            try
            {
                var id = await _adminSvc.AddDepartment(department);
                department.DepartmentId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditDepartment")]
        public async Task<ActionResult<int>> EditDepartment(DepartmentModel Department)
        {
            try
            {
                await _adminSvc.EditDepartment(Department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteDepartment/{id}")]
        public async Task<ActionResult<int>> DeleteDepartment(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteDepartment(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }


        //Subject (môn học)
        [HttpGet]
        [Route("ListSubject")]
        public async Task<ActionResult<IEnumerable<SubjectModel>>> ListSubject()
        {
            var list = await _adminSvc.GetSubject();
            return list;
        }//danh sách môn học

        [HttpGet]
        [Route("ListSubjectAll")]
        public async Task<ActionResult<IEnumerable<SubjectModel>>> ListAllSubject()
        {
            var list = await _adminSvc.GetSubjectAll();
            return list;
        }//show hết môn học

        [HttpGet]
        [Route("SubjectId")]
        public async Task<ActionResult<IEnumerable<SubjectModel>>> ListSubjectId(SubjectModel subjectModel)
        {
            var list = await _adminSvc.GetSubjectId(subjectModel);
            return list;
        }//tìm kiếm môn học

        [HttpPost]
        [Route("AddSubject")]
        public async Task<ActionResult<int>> AddSubject(SubjectModel subjectModel)
        {
            try
            {
                var id = await _adminSvc.AddSubject(subjectModel);
                subjectModel.SubjectId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }// thêm môn học

        [HttpPost]
        [Route("EditSubject")]
        public async Task<ActionResult<int>> EditSubject(SubjectModel subjectModel) //sửa môn học
        {
            try
            {
                await _adminSvc.EditSubject(subjectModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteSubject/{id}")]
        public async Task<ActionResult<int>> DeleteSubject(int id) //xóa môn học
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteSubject(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        // Class (lớp học)
        [HttpGet]
        [Route("ListLopHoc")]
        public async Task<ActionResult<IEnumerable<ClassModel>>> ListLopHoc()
        {
            var list = await _adminSvc.GetLopHoc();
            return list;
        }

        [HttpGet]
        [Route("ListLopHocStudent")]
        public async Task<ActionResult<IEnumerable<UserModel>>> ListLopHocStudent(ClassModel classModel)
        {
            var list = await _adminSvc.GetLopHocStudent(classModel);
            return list;
        }

        [HttpGet]
        [Route("LopHocId")]
        public async Task<ActionResult<IEnumerable<ClassModel>>> LopHocId(ClassModel classModel)
        {
            var list = await _adminSvc.GetLopHocId(classModel);
            return list;
        }

        [HttpPost]
        [Route("AddLopHoc")]
        public async Task<ActionResult<int>> AddLopHoc(ClassModel classModel)
        {
            try
            {
                var id = await _adminSvc.AddLopHoc(classModel);
                classModel.ClassId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new{
            retText ="that bai"
            });
        }

        [HttpPost]
        [Route("EditLopHoc")]
        public async Task<ActionResult<int>> EditLopHoc(ClassModel classModel)
        {
            try
            {
                await _adminSvc.EditLopHoc(classModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteLopHoc/{id}")]
        public async Task<ActionResult<int>> DeleteLopHoc(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteLopHoc(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        //Score Type
        [HttpGet]
        [Route("ListScoreType")]
        public async Task<ActionResult<IEnumerable<ScoreTypeModel>>> ListAllScoreType()
        {
            var list = await _adminSvc.GetScoreType();
            return list;
        }

        [HttpPost]
        [Route("AddScoreType")]
        public async Task<ActionResult<int>> AddScoreType(ScoreTypeModel scoreTypeModel)
        {
            try
            {
                var id = await _adminSvc.AddScoreType(scoreTypeModel);
                scoreTypeModel.ScoreTypeId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditScoreType")]
        public async Task<ActionResult<int>> EditScoreType(ScoreTypeModel scoreTypeModel)
        {
            try
            {
                await _adminSvc.EditScoreType(scoreTypeModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteScoreType/{id}")]
        public async Task<ActionResult<int>> DeleteScoreType(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteScoreType(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        //Score
        [HttpGet]
        [Route("ListScore")]
        public async Task<ActionResult<IEnumerable<ScoreModel>>> ListAllScore()
        {
            var list = await _adminSvc.GetScore();
            return list;
        }

        [HttpGet]
        [Route("ListScoreAll")]
        public async Task<ActionResult<IEnumerable<ScoreModel>>> ListScoreAll()
        {
            var list = await _adminSvc.GetScoreAll();
            return list;
        }

        [HttpGet]
        [Route("ScoreId")]
        public async Task<ActionResult<IEnumerable<ScoreModel>>> ScoreId(ScoreModel scoreModel)
        {
            var list = await _adminSvc.GetScoreId(scoreModel);
            return list;
        }

        [HttpPost]
        [Route("AddScore")]
        public async Task<ActionResult<int>> AddScore(ScoreModel scoreModel)
        {
            try
            {
                int id = await _adminSvc.AddScore(scoreModel);
                scoreModel.ScoreId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditScore")]
        public async Task<ActionResult<int>> EditScore(ScoreModel scoreModel)
        {
            try
            {
                int id = await _adminSvc.EditScore(scoreModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteScore/{id}")]
        public async Task<ActionResult<int>> DeleteScore(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteScore(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        //Schedule lịch dạy
        [HttpGet]
        [Route("ListSchedule")]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> ListSchedule()
        {
            var list = await _adminSvc.GetSchedule();
            return list;
        }

        [HttpGet]
        [Route("ScheduleId")]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> ScheduleId(ScheduleModel scheduleModel)
        {
            var list = await _adminSvc.ScheduleId(scheduleModel);
            return list;
        }

        [HttpPost]
        [Route("AddSchedule")]
        public async Task<ActionResult<int>> AddSchedule(ScheduleModel scheduleModel)
        {
            try
            {
                int id = await _adminSvc.AddSchedule(scheduleModel);
                scheduleModel.ScheduleId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditSchedule")]
        public async Task<ActionResult<int>> EditSchedule(ScheduleModel scheduleModel)
        {
            try
            {
                await _adminSvc.EditSchedule(scheduleModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteSchedule/{id}")]
        public async Task<ActionResult<int>> DeleteSchedule(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteSchedule(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        //ngày nghỉ
        [HttpGet]
        [Route("ListScheduleHoliDay")]
        public async Task<ActionResult<IEnumerable<ScheduleHoliday>>> ListScheduleHoliday()
        {
            var list = await _adminSvc.GetScheduleHoliday();
            return list;
        }

        [HttpGet]
        [Route("ScheduleHolidayId")]
        public async Task<ActionResult<IEnumerable<ScheduleHoliday>>> ScheduleHolidayId(ScheduleHoliday scheduleHoliday)
        {
            var list = await _adminSvc.ScheduleHolidayId(scheduleHoliday);
            return list;
        }

        [HttpPost]
        [Route("AddScheduleHoliday")]
        public async Task<ActionResult<int>> AddScheduleHoliday(ScheduleHoliday scheduleHoliday)
        {
            try
            {
                int id = await _adminSvc.AddScheduleHoliday(scheduleHoliday);
                scheduleHoliday.ScheduleHolidayId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditScheduleHoliday")]
        public async Task<ActionResult<int>> EditScheduleHoliday(ScheduleHoliday scheduleHoliday)
        {
            try
            {
                await _adminSvc.EditScheduleHoliday(scheduleHoliday);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteScheduleHoliday/{id}")]
        public async Task<ActionResult<int>> DeleteScheduleHoliday(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteScheduleHoliday(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }
    }
}
