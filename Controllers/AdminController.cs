using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
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
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _adminSvc;

        public AdminController(IAdmin adminSvc)
        {
            _adminSvc = adminSvc;
        }

        //role
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

<<<<<<< HEAD
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

        //
=======
>>>>>>> 40c902cfa6e06aff13c1844709aaadef4866589c
    }
}
