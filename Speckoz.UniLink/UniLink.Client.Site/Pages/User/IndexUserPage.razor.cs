﻿using UniLink.Client.Site.Attributes;
using UniLink.Dependencies.Enums;

namespace UniLink.Client.Site.Pages.User
{
	[Authorizes(UserTypeEnum.Student)]
	public partial class IndexUserPage
	{
	}
}