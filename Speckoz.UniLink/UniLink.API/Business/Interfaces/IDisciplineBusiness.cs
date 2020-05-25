﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using UniLink.Dependencies.Data.VO;

namespace UniLink.API.Business.Interfaces
{
	public interface IDisciplineBusiness
	{
		Task<DisciplineVO> AddTaskAsync(DisciplineVO discipline);

		Task<bool> ExistsByNameAndCourseIdTaskAsync(string name, Guid courseId);

		Task<bool> ExistsByDisciplineIdTaskAsync(Guid disciplineId);

		Task<List<DisciplineVO>> FindAllByDisciplineIdsTaskAsync(List<Guid> disciplines);

		Task<DisciplineVO> FindByDisciplineIdTaskAsync(Guid disciplineId);

		Task<List<DisciplineVO>> FindByCourseIdTaskAsync(Guid courseId);

		Task<DisciplineVO> UpdateTaskAync(DisciplineVO newDiscipline);

		Task DeleteTaskAsync(Guid disciplineId);
	}
}