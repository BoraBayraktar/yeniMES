////using MES.Business;
//using MES.Web.Model;
//using MES.Web.Models;
//using Newtonsoft.Json;
//using Novell.Directory.Ldap;
////using NUglify.Helpers;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;

//namespace MES.Web.Ldap
//{
//	public class LdapHelper
//	{
//		public static bool LdapConnectionVerify(string ServerAddress, int PortNumber, string username, string password)
//		{
//			try
//			{
//				var conn = new LdapConnection();
//				conn.Connect(ServerAddress, PortNumber);
//				conn.Bind(username, password);
//				var result = conn.Connected;
//				conn.Disconnect();
//				return result;
//			}
//			catch (Exception ex)
//			{
//				return false;
//			}
//		}

//        public static Dictionary<string, HashSet<string>> SearchForGroup(string ServerAddress, int PortNumber, string SearchBase, string username, string password)
//        {
//			var ouModels = new HashSet<string>();
//			var ldapUsers = new List<string>();
//			var groups = new Dictionary<string,HashSet<string>>();
			
//			try
//			{
//				var filter = $"(&(objectClass=Person)(objectClass=user))";
//				using (var conn = new LdapConnection())
//				{
//					try
//					{
//						conn.Connect(ServerAddress,PortNumber);
//						conn.Bind(username, password);
//						var search = conn.Search(SearchBase, LdapConnection.ScopeSub, filter, null, false);
						
//						while (search.HasMore())
//						{
//							try
//							{
//								LdapEntry nextEntry = search?.Next();
//								LdapAttributeSet attributeSet = nextEntry.GetAttributeSet();
//								var objectClassAttribute = attributeSet.GetAttribute("objectClass").StringValueArray;
//								var distName = attributeSet.GetAttribute("distinguishedName")?.StringValueArray[0];
//								var ouModel = distName.Split(',').FirstOrDefault(x => x.Contains("OU"));
								
//								Debug.WriteLine(objectClassAttribute);
//								if (!objectClassAttribute.Contains("computer"))
//								{
//									if (ouModel != null) 
//									{
//										ouModels.Add(ouModel);
//										ldapUsers.Add(distName.ToString());
//									} 
//								}
//							}
//							catch (Exception ex)
//							{
//								Debug.WriteLine(ex.Message);
//							}
//						}
//						foreach (var item in ouModels)
//						{
//							groups.Add(item, new HashSet<string>(ldapUsers.Where(x=>x.Contains(item))));
//						}
//					}
//					catch (Exception ex)
//					{
//						Debug.WriteLine(ex.Message);
//					}
//				}
//			}
//			catch (Exception ex)
//			{
//				Debug.WriteLine(ex.Message);
//			}
//			return groups;
//        }

//		public static List<LdapUserViewModel>SearchForUser(string ServerAddress, int PortNumber, string SearchBase, string username, string password,HashSet<string> groups = null)
//		{
//			var users = new List<LdapUserViewModel>();
//			try
//			{

//				foreach (var item in groups)
//				{
//					using (var conn = new LdapConnection())
//					{
//						try
//						{
//							conn.Connect(ServerAddress, PortNumber);
//							conn.Bind(username, password);
//							var search = conn.Search(item, LdapConnection.ScopeSub, string.Empty, null, false);

//							while (search.HasMore())
//							{
//								try
//								{
//									string name, surname, ldapusername, mail, attributePassword = null;
//									bool active = false;
//									var nextEntry = search.Next();
//									LdapAttributeSet attributeSet = nextEntry.GetAttributeSet();
//									#region name
//									try
//									{
//										name = attributeSet.GetAttribute("cn")?.StringValueArray[0];
//									}
//									catch
//									{
//										name = string.Empty;
//									}
//									#endregion
//									#region surname
//									try
//									{
//										surname = attributeSet.GetAttribute("sn")?.StringValueArray[0];
//									}
//									catch
//									{
//										surname = string.Empty;
//									}
//									#endregion
//									#region username
//									try
//									{
//										ldapusername = attributeSet.GetAttribute("sAMAccountName")?.StringValueArray[0];
//									}
//									catch
//									{
//										ldapusername = string.Empty;
//									}
//									#endregion
//									#region mail
//									try
//									{
//										mail = attributeSet.GetAttribute("mail")?.StringValueArray[0];
//									}
//									catch
//									{
//										mail = string.Empty;
//									}
//									#endregion
//									#region password
//									try
//									{
//										attributePassword = attributeSet.GetAttribute("userpassword")?.StringValueArray[0];
//									}
//									catch
//									{
//										attributePassword = string.Empty;
//									}
//									#endregion
//									#region enabled
//									try
//									{
//										var flags =Convert.ToInt32( attributeSet.GetAttribute("userAccountControl")?.StringValueArray[0]);
//										active = !Convert.ToBoolean(flags & 0x0002);
//									}
//									catch
//									{
//										active = true;
//									}
									

//									//return !Convert.ToBoolean(flags & 0x0002);
//									#endregion
//									users.Add(new LdapUserViewModel()
//									{
//										NAME = name,
//										SURNAME = surname,
//										EMAIL = mail,
//										USER_TYPE_ID = 2,
//										DEPARTMENT_ID=1,
//										LOCATION_ID=1,
//										TITLE_ID =1,
//										ISLDAP = true,
//										USER_ISACTIVE = active,
//										USERNAME = ldapusername,
//										PASSWORD = attributePassword
//									});;
//								}
//								catch (Exception ex)
//								{
//									Debug.WriteLine(ex.Message);
//								}
//							}
//						}
//						catch (Exception)
//						{
//							throw;
//						}
//					}
//				}
//			}
//			catch (Exception ex)
//			{
//				throw new Exception(ex.Message);
//			}
//			return users;
//		}
//	}
//}
