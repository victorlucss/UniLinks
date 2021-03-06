﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using UniLinks.Dependencies.Data.VO.Student;

namespace UniLinks.API.Business.Interfaces
{
	public interface IStudentBusiness
	{
		Task<AuthStudentVO> AuthUserTaskAsync(string email);

		Task<StudentDisciplineVO> AddTaskAsync(StudentVO student);

		Task<bool> ExistsByEmailTaskAsync(string email);

		Task<bool> ExistsStudentWithDisciplineTaskAsync(Guid disciplineId);

		Task<int> FindCountByCourseIdTaskAsync(Guid courseId);

		Task<StudentDisciplineVO> FindByStudentIdTaskAsync(Guid id);

		Task<List<StudentDisciplineVO>> FindAllByCourseIdTaskAsync(Guid courseId);

		Task<StudentDisciplineVO> UpdateTaskAsync(StudentVO newStudent);

		Task DeleteTaskAsync(Guid id);
	}
}