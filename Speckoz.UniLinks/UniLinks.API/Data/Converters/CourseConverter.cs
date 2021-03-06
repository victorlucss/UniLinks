﻿using System.Collections.Generic;
using System.Linq;

using UniLinks.API.Data.Converters.Interfaces;
using UniLinks.Dependencies.Data.VO;
using UniLinks.Dependencies.Models;

namespace UniLinks.API.Data.Converters
{
	public class CourseConverter : IParser<CourseVO, CourseModel>, IParser<CourseModel, CourseVO>
	{
		public CourseModel Parse(CourseVO origin)
		{
			if (origin is null)
				return null;

			return new CourseModel
			{
				CoordinatorId = origin.CoordinatorId,
				Name = origin.Name,
				CourseId = origin.CourseId,
				Periods = origin.Periods
			};
		}

		public CourseVO Parse(CourseModel origin)
		{
			if (origin is null)
				return null;

			return new CourseVO
			{
				CoordinatorId = origin.CoordinatorId,
				Name = origin.Name,
				CourseId = origin.CourseId,
				Periods = origin.Periods
			};
		}

		public List<CourseModel> ParseList(List<CourseVO> origin)
		{
			return origin switch
			{
				null => null,
				_ => origin.Select(item => Parse(item)).ToList()
			};
		}

		public List<CourseVO> ParseList(List<CourseModel> origin)
		{
			return origin switch
			{
				null => null,
				_ => origin.Select(item => Parse(item)).ToList()
			};
		}
	}
}