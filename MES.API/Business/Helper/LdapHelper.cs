using MES.DB.Model;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using MES.API.Business;

namespace MES.API.Helper
{
	public class LdapHelper
	{
		LdapInfoLogic _ldapLogic;
		static LDAP_INFO ldapInfoModel = null;
		public LdapHelper()
		{
			_ldapLogic = new LdapInfoLogic();
			ldapInfoModel = _ldapLogic.Get();

		}

		public static bool LdapConnectionVerify(string ServerAddress, int PortNumber, string username, string password)
		{
			try
			{
				var conn = new LdapConnection();
				conn.Connect(ServerAddress, PortNumber);
				conn.Bind(username, password);
				var result = conn.Connected;
				conn.Disconnect();
				return result;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public static Dictionary<string, HashSet<string>> SearchForGroup()
		{
			var groups = new Dictionary<string, HashSet<string>>();
			try
			{
				var filter = $"(ou=*)";
				string searchBase = "DC=example,DC=com";

				using (var conn = new LdapConnection())
				{
					try
					{
						conn.Connect(ldapInfoModel.ServerAddress, ldapInfoModel.PortNumber);
						conn.Bind(ldapInfoModel.Username, ldapInfoModel.Password);
						var search = conn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);

						while (search.HasMore())
						{
							try
							{
								LdapEntry nextEntry = search?.Next();
								LdapAttributeSet attributeSet = nextEntry.GetAttributeSet();
								var firstArray = new List<string>(attributeSet.GetAttribute("uniqueMember").StringValueArray);
								var ldapStringArray = new List<string>();
								firstArray.ForEach(x => ldapStringArray.Add(x.Split(',').FirstOrDefault()));
								var ouModel = nextEntry.Dn.Split(',').FirstOrDefault();
								groups.Add(ouModel, new HashSet<string>(firstArray));
							}
							catch (Exception ex)
							{
								Debug.WriteLine(ex.Message);
							}
						}
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.Message);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return groups;
		}

		public static List<USER> SearchForUser(HashSet<string> groups = null)
		{
			var users = new List<USER>();
			var _ldapLogic = new LdapInfoLogic();
			var ldapInfoModel = _ldapLogic.Get();
			try
			{
				

				foreach (var item in groups)
				{
					using (var conn = new LdapConnection())
					{
						try
						{
							conn.Connect(ldapInfoModel.ServerAddress, ldapInfoModel.PortNumber);
							conn.Bind(ldapInfoModel.Username, ldapInfoModel.Password);
							var search = conn.Search(item, LdapConnection.ScopeSub, string.Empty, null, false);

							while (search.HasMore())
							{
								try
								{
									var nextEntry = search.Next();
									LdapAttributeSet attributeSet = nextEntry.GetAttributeSet();
									var name = attributeSet.GetAttribute("cn").StringValueArray;
									var surname = attributeSet.GetAttribute("sn").StringValueArray;
									var mail = attributeSet.GetAttribute("mail").StringValueArray;
									string attributePassword = null;
									try
									{
										attributePassword = attributeSet.GetAttribute("userpassword")?.StringValueArray[0];
									}
									catch
									{
										attributePassword = string.Empty;
									}

									users.Add(new USER()
									{
										NAME = name[0],
										SURNAME = surname[0],
										EMAIL = mail[0],
										USER_TYPE_ID = 2,
										DEPARTMENT_ID = 1,
										LOCATION_ID = 1,
										TITLE_ID = 1,
										ISLDAP = true,
										USERNAME = name[0] + "." + surname[0],
										PASSWORD = attributePassword
									});
								}
								catch (Exception ex)
								{
									Debug.WriteLine(ex.Message);
								}
							}
						}
						catch (Exception)
						{
							throw;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return users;
		}
	}
}

