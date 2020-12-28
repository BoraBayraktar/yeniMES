using MES.API.Interfaces;
using MES.DB;
using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Transactions;

namespace MES.API.Functions
{
    public class IncidentFunctions : IIncident
    {
        public List<INCIDENT> GetList()
        {
            using (MesContext context = new MesContext())
            {
                var incidentList = context.INCIDENT.Include(q => q.CREATED_USER)
                                                   .Include(q => q.REPORTING_USER)
                                                   .Include(q => q.INCIDENT_STATUS)
                                                   .Include(q => q.INCIDENT_PRIORITY)
                                                   .Where(q => q.IS_DELETED == false)
                                                   .OrderByDescending(q => q.ID)
                                                   .ToList();
                return incidentList;
            }
        }
        public INCIDENT GetIncident(int id)
        {
            using (MesContext context = new MesContext())
            {
                var incident = context.INCIDENT.Include(q => q.CREATED_USER).Include(q => q.CREATED_USER.DEPARTMENT).FirstOrDefault(q => q.ID == id);
                return incident;
            }
        }
        public bool InsertIncident(INCIDENT incident)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    incident.CREATED_DATE = DateTime.Now;

                    //var _incident = context.INCIDENT.FirstOrDefault(q => q.CODE == incident.CODE);
                    //if (_incident != null)
                    //{
                    //    incident.CODE = MaxCode();
                    //}

                    incident.CODE = MaxCode();


                    context.INCIDENT.Add(incident);
                    context.SaveChanges();


                    var Incident = context.INCIDENT.Include(q => q.CREATED_USER)
                                                       .Include(q => q.ASSIGNED_USER)
                                                       .Include(q => q.INCIDENT_STATUS)
                                                       .Include(q => q.CATEGORY)
                                                       .Include(q => q.SUB_CATEGORY)
                                                       .Include(q => q.INCIDENT_PRIORITY)
                                                       .Include(q => q.INCIDENT_IMPACT)
                                                       .Include(q => q.ASSIGNED_GROUP)
                                                       .Include(q => q.ASSIGNED_USER)
                                                       .Include(q => q.INCIDENT_SOURCE)
                                                       .Include(q => q.INCIDENT_TYPE)
                                                       .Include(q => q.SERVICE_CATALOG)
                        .FirstOrDefault(q => q.ID == incident.ID);


                    returnVal = true;

                    if (Incident != null)
                    {


                        returnVal = SendMailAndSurvey(Incident);

                        //var emailTemplate = context.EMAIL_TEMPLATE.FirstOrDefault(q => q.IS_DELETED == false && q.MAIN_PROCESS_STATUS_ID == Incident.INCIDENT_STATUS_ID);
                        //if (emailTemplate != null)
                        //{
                        //    string body = emailTemplate.BODY.Replace("@adSoyad", (Incident.CREATED_USER.NAME + " " + Incident.CREATED_USER.SURNAME))
                        //                                           .Replace("@bildirilenAciliyet", Incident.INCIDENT_PRIORITY != null ? Incident.INCIDENT_PRIORITY.MAIN_DATA_NAME : "")
                        //                                           .Replace("@konu", Incident.SUBJECT)
                        //                                           .Replace("@aciklama", Incident.DESCRIPTION)
                        //                                           .Replace("@tarih", Incident.CREATED_DATE.ToString())
                        //                                           .Replace("@hizmet", Incident.SERVICE_CATALOG != null ? Incident.SERVICE_CATALOG.SERVICE_NAME : "")
                        //                                           .Replace("@kategori", Incident.CATEGORY != null ? Incident.CATEGORY.MAIN_DATA_NAME : "")
                        //                                           .Replace("@altKategori", Incident.SUB_CATEGORY != null ? Incident.SUB_CATEGORY.MAIN_DATA_NAME : "")
                        //                                           .Replace("@etki", Incident.INCIDENT_IMPACT != null ? Incident.INCIDENT_IMPACT.MAIN_DATA_NAME : "")
                        //                                           .Replace("@sorunTipi", Incident.INCIDENT_TYPE != null ? Incident.INCIDENT_TYPE.MAIN_DATA_NAME : "")
                        //                                           .Replace("@sorunBildirimKaynagi", Incident.INCIDENT_SOURCE != null ? Incident.INCIDENT_SOURCE.MAIN_DATA_NAME : "")
                        //                                           .Replace("@iliskiliVarlik", "")
                        //                                           .Replace("@atananGrup", Incident.ASSIGNED_GROUP != null ? Incident.ASSIGNED_GROUP.GROUP_NAME : "")
                        //                                           .Replace("@atananKisi", Incident.ASSIGNED_USER != null ? Incident.ASSIGNED_USER.NAME + " " + Incident.ASSIGNED_USER.SURNAME : "")
                        //                                           .Replace("@cozumKodu", "")
                        //                                           .Replace("@cozumAciklamasi", "")
                        //                                           .Replace("@durum", Incident.INCIDENT_STATUS != null ? Incident.INCIDENT_STATUS.MAIN_DATA_NAME : "")
                        //                                           .Replace("@kod", Incident.CODE);

                        //    string subject = emailTemplate.SUBJECT.Replace("@adSoyad", Incident.CREATED_USER.NAME + " " + Incident.CREATED_USER.SURNAME)
                        //               .Replace("@bildirilenAciliyet", Incident.INCIDENT_PRIORITY != null ? Incident.INCIDENT_PRIORITY.MAIN_DATA_NAME : "")
                        //               .Replace("@konu", Incident.SUBJECT)
                        //               .Replace("@aciklama", Incident.DESCRIPTION)
                        //               .Replace("@tarih", Incident.CREATED_DATE.ToString())
                        //               .Replace("@hizmet", Incident.SERVICE_CATALOG != null ? Incident.SERVICE_CATALOG.SERVICE_NAME : "")
                        //               .Replace("@kategori", Incident.CATEGORY != null ? Incident.CATEGORY.MAIN_DATA_NAME : "")
                        //               .Replace("@altKategori", Incident.SUB_CATEGORY != null ? Incident.SUB_CATEGORY.MAIN_DATA_NAME : "")
                        //               .Replace("@etki", Incident.INCIDENT_IMPACT != null ? Incident.INCIDENT_IMPACT.MAIN_DATA_NAME : "")
                        //               .Replace("@sorunTipi", Incident.INCIDENT_TYPE != null ? Incident.INCIDENT_TYPE.MAIN_DATA_NAME : "")
                        //               .Replace("@sorunBildirimKaynagi", Incident.INCIDENT_SOURCE != null ? Incident.INCIDENT_SOURCE.MAIN_DATA_NAME : "")
                        //               .Replace("@iliskiliVarlik", "")
                        //               .Replace("@atananGrup", Incident.ASSIGNED_GROUP != null ? Incident.ASSIGNED_GROUP.GROUP_NAME : "")
                        //               .Replace("@atananKisi", Incident.ASSIGNED_USER != null ? Incident.ASSIGNED_USER.NAME + " " + Incident.ASSIGNED_USER.SURNAME : "")
                        //               .Replace("@cozumKodu", "")
                        //               .Replace("@cozumAciklamasi", "")
                        //               .Replace("@durum", Incident.INCIDENT_STATUS != null ? Incident.INCIDENT_STATUS.MAIN_DATA_NAME : "")
                        //               .Replace("@kod", Incident.CODE);

                        //    if (emailTemplate.TO_CREATED_USER != null)
                        //    {
                        //        MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                        //        {
                        //            CREATED_DATE = DateTime.Now,
                        //            CREATED_USER_ID = incident.CREATED_USER_ID,
                        //            IS_DELETED = false,
                        //            IS_SENT = false,
                        //            TO_ADDRESS = Incident.CREATED_USER.EMAIL,
                        //            MAIL_SUBJECT = subject,
                        //            MAIL_BODY = body,
                        //            MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                        //        };
                        //        context.MAIL_TO_SEND.Add(mailToSend);
                        //        context.SaveChanges();
                        //    }
                        //    if (emailTemplate.TO_ASSIGNED_USER != null)
                        //    {
                        //        if (Incident.ASSIGNED_USER != null)
                        //        {
                        //            MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                        //            {
                        //                CREATED_DATE = DateTime.Now,
                        //                CREATED_USER_ID = incident.CREATED_USER_ID,
                        //                IS_DELETED = false,
                        //                IS_SENT = false,
                        //                TO_ADDRESS = Incident.ASSIGNED_USER.EMAIL,
                        //                MAIL_SUBJECT = subject,
                        //                MAIL_BODY = body,
                        //                MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                        //            };
                        //            context.MAIL_TO_SEND.Add(mailToSend);
                        //            context.SaveChanges();
                        //        }

                        //    }
                        //    if (emailTemplate.TO_ASSIGNED_GROUP_USER != null)
                        //    {
                        //        var groupExpert = context.GROUP_EXPERT.Where(q => q.GROUP_ID == Incident.ASSIGNED_GROUP_ID).ToList();
                        //        if (groupExpert != null)
                        //        {
                        //            foreach (var item in groupExpert)
                        //            {
                        //                MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                        //                {
                        //                    CREATED_DATE = DateTime.Now,
                        //                    CREATED_USER_ID = incident.CREATED_USER_ID,
                        //                    IS_DELETED = false,
                        //                    IS_SENT = false,
                        //                    TO_ADDRESS = item.EXPERT_EMAIL,
                        //                    MAIL_SUBJECT = subject,
                        //                    MAIL_BODY = body,
                        //                    MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                        //                };
                        //                context.MAIL_TO_SEND.Add(mailToSend);
                        //                context.SaveChanges();
                        //            }
                        //        }

                        //    }
                        //    if (!String.IsNullOrEmpty(emailTemplate.TO_USERS))
                        //    {
                        //        var userList = emailTemplate.TO_USERS.Split(",");
                        //        for (int i = 0; i < userList.Length; i++)
                        //        {
                        //            MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                        //            {
                        //                CREATED_DATE = DateTime.Now,
                        //                CREATED_USER_ID = incident.CREATED_USER_ID,
                        //                IS_DELETED = false,
                        //                IS_SENT = false,
                        //                TO_ADDRESS = userList[i],
                        //                MAIL_SUBJECT = subject,
                        //                MAIL_BODY = body,
                        //                MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                        //            };
                        //            context.MAIL_TO_SEND.Add(mailToSend);
                        //            context.SaveChanges();
                        //        }
                        //    }
                        //    if (emailTemplate.TO_GROUPS != null)
                        //    {
                        //        var groupList = emailTemplate.TO_GROUPS.Split(",");
                        //        for (int i = 0; i < groupList.Length; i++)
                        //        {
                        //            MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                        //            {
                        //                CREATED_DATE = DateTime.Now,
                        //                CREATED_USER_ID = incident.CREATED_USER_ID,
                        //                IS_DELETED = false,
                        //                IS_SENT = false,
                        //                TO_ADDRESS = groupList[i],
                        //                MAIL_SUBJECT = subject,
                        //                MAIL_BODY = body,
                        //                MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                        //            };
                        //            context.MAIL_TO_SEND.Add(mailToSend);
                        //            context.SaveChanges();
                        //        }
                        //    }

                        //}
                    }


                    //returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool UpdateIncident(INCIDENT incident)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var Incident = context.INCIDENT.FirstOrDefault(q => q.ID == incident.ID);
                    if (Incident != null)
                    {
                        Incident.DESCRIPTION = incident.DESCRIPTION;
                        Incident.INCIDENT_PRIORITY_ID = incident.INCIDENT_PRIORITY_ID;
                        Incident.REPORTING_USER_ID = incident.REPORTING_USER_ID;
                        Incident.SUBJECT = incident.SUBJECT;
                        Incident.INCIDENT_STATUS_ID = incident.INCIDENT_STATUS_ID;
                        Incident.UPDATED_DATE = DateTime.Now;
                        Incident.UPDATED_USER_ID = incident.UPDATED_USER_ID;

                        Incident.ASSIGNED_GROUP_ID = incident.ASSIGNED_GROUP_ID;
                        Incident.ASSIGNED_USER_ID = incident.ASSIGNED_USER_ID;

                    }
                    context.Entry(Incident).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool UpdateIncidentDetail(INCIDENT incident)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var Incident = context.INCIDENT.Include(q => q.CREATED_USER)
                                                       .Include(q => q.ASSIGNED_USER)
                                                       .Include(q => q.INCIDENT_STATUS)
                                                       .Include(q => q.CATEGORY)
                                                       .Include(q => q.SUB_CATEGORY)
                                                       .Include(q => q.INCIDENT_PRIORITY)
                                                       .Include(q => q.INCIDENT_IMPACT)
                                                       .Include(q => q.ASSIGNED_GROUP)
                                                       .Include(q => q.ASSIGNED_USER)
                                                       .Include(q => q.INCIDENT_SOURCE)
                                                       .Include(q => q.INCIDENT_TYPE)
                                                       .Include(q => q.SERVICE_CATALOG)
                                                   .FirstOrDefault(q => q.ID == incident.ID);
                    if (Incident != null)
                    {
                        Incident.INCIDENT_PRIORITY_ID = incident.INCIDENT_PRIORITY_ID;
                        Incident.SERVICE_CATALOG_ID = incident.SERVICE_CATALOG_ID == 0 ? null : incident.SERVICE_CATALOG_ID;
                        Incident.CATEGORY_ID = incident.CATEGORY_ID == 0 ? null : incident.CATEGORY_ID;
                        Incident.SUB_CATEGORY_ID = incident.SUB_CATEGORY_ID == 0 ? null : incident.SUB_CATEGORY_ID;
                        Incident.INCIDENT_URGENCY_ID = incident.INCIDENT_URGENCY_ID == 0 ? null : incident.INCIDENT_URGENCY_ID;
                        Incident.INCIDENT_IMPACT_ID = incident.INCIDENT_IMPACT_ID == 0 ? null : incident.INCIDENT_IMPACT_ID;
                        Incident.INCIDENT_TYPE_ID = incident.INCIDENT_TYPE_ID == 0 ? null : incident.INCIDENT_TYPE_ID;
                        Incident.INCIDENT_SOURCE_ID = incident.INCIDENT_SOURCE_ID == 0 ? null : incident.INCIDENT_SOURCE_ID;
                        Incident.ASSIGNED_GROUP_ID = incident.ASSIGNED_GROUP_ID == 0 ? null : incident.ASSIGNED_GROUP_ID;
                        Incident.ASSIGNED_USER_ID = incident.ASSIGNED_USER_ID == 0 ? null : incident.ASSIGNED_USER_ID;

                        Incident.INCIDENT_STATUS_ID = incident.INCIDENT_STATUS_ID;


                        Incident.UPDATED_DATE = DateTime.Now;
                        Incident.UPDATED_USER_ID = incident.UPDATED_USER_ID;
                    }
                    context.Entry(Incident).State = EntityState.Modified;
                    context.SaveChanges();

                    returnVal = true;


                    returnVal = SendMailAndSurvey(Incident);

                    //var emailTemplate = context.EMAIL_TEMPLATE.FirstOrDefault(q => q.IS_DELETED == false && q.MAIN_PROCESS_STATUS_ID == incident.INCIDENT_STATUS_ID);
                    //if (emailTemplate != null)
                    //{
                    //    string body = emailTemplate.BODY.Replace("@adSoyad", Incident.CREATED_USER.NAME + " " + Incident.CREATED_USER.SURNAME)
                    //                                           .Replace("@bildirilenAciliyet", Incident.INCIDENT_PRIORITY != null ? Incident.INCIDENT_PRIORITY.MAIN_DATA_NAME : "")
                    //                                           .Replace("@konu", Incident.SUBJECT)
                    //                                           .Replace("@aciklama", Incident.DESCRIPTION)
                    //                                           .Replace("@tarih", Incident.CREATED_DATE.ToString())
                    //                                           .Replace("@hizmet", Incident.SERVICE_CATALOG != null ? Incident.SERVICE_CATALOG.SERVICE_NAME : "")
                    //                                           .Replace("@kategori", Incident.CATEGORY != null ? Incident.CATEGORY.MAIN_DATA_NAME : "")
                    //                                           .Replace("@altKategori", Incident.SUB_CATEGORY != null ? Incident.SUB_CATEGORY.MAIN_DATA_NAME : "")
                    //                                           .Replace("@etki", Incident.INCIDENT_IMPACT != null ? Incident.INCIDENT_IMPACT.MAIN_DATA_NAME : "")
                    //                                           .Replace("@sorunTipi", Incident.INCIDENT_TYPE != null ? Incident.INCIDENT_TYPE.MAIN_DATA_NAME : "")
                    //                                           .Replace("@sorunBildirimKaynagi", Incident.INCIDENT_SOURCE != null ? Incident.INCIDENT_SOURCE.MAIN_DATA_NAME : "")
                    //                                           .Replace("@iliskiliVarlik", "")
                    //                                           .Replace("@atananGrup", Incident.ASSIGNED_GROUP != null ? Incident.ASSIGNED_GROUP.GROUP_NAME : "")
                    //                                           .Replace("@atananKisi", Incident.ASSIGNED_USER != null ? Incident.ASSIGNED_USER.NAME + " " + Incident.ASSIGNED_USER.SURNAME : "")
                    //                                           .Replace("@cozumKodu", "")
                    //                                           .Replace("@cozumAciklamasi", "")
                    //                                           .Replace("@durum", Incident.INCIDENT_STATUS != null ? Incident.INCIDENT_STATUS.MAIN_DATA_NAME : "")
                    //                                           .Replace("@kod", Incident.CODE);


                    //    string subject = emailTemplate.SUBJECT.Replace("@adSoyad", Incident.CREATED_USER.NAME + " " + Incident.CREATED_USER.SURNAME)
                    //       .Replace("@bildirilenAciliyet", Incident.INCIDENT_PRIORITY != null ? Incident.INCIDENT_PRIORITY.MAIN_DATA_NAME : "")
                    //       .Replace("@konu", Incident.SUBJECT)
                    //       .Replace("@aciklama", Incident.DESCRIPTION)
                    //       .Replace("@tarih", Incident.CREATED_DATE.ToString())
                    //       .Replace("@hizmet", Incident.SERVICE_CATALOG != null ? Incident.SERVICE_CATALOG.SERVICE_NAME : "")
                    //       .Replace("@kategori", Incident.CATEGORY != null ? Incident.CATEGORY.MAIN_DATA_NAME : "")
                    //       .Replace("@altKategori", Incident.SUB_CATEGORY != null ? Incident.SUB_CATEGORY.MAIN_DATA_NAME : "")
                    //       .Replace("@etki", Incident.INCIDENT_IMPACT != null ? Incident.INCIDENT_IMPACT.MAIN_DATA_NAME : "")
                    //       .Replace("@sorunTipi", Incident.INCIDENT_TYPE != null ? Incident.INCIDENT_TYPE.MAIN_DATA_NAME : "")
                    //       .Replace("@sorunBildirimKaynagi", Incident.INCIDENT_SOURCE != null ? Incident.INCIDENT_SOURCE.MAIN_DATA_NAME : "")
                    //       .Replace("@iliskiliVarlik", "")
                    //       .Replace("@atananGrup", Incident.ASSIGNED_GROUP != null ? Incident.ASSIGNED_GROUP.GROUP_NAME : "")
                    //       .Replace("@atananKisi", Incident.ASSIGNED_USER != null ? Incident.ASSIGNED_USER.NAME + " " + Incident.ASSIGNED_USER.SURNAME : "")
                    //       .Replace("@cozumKodu", "")
                    //       .Replace("@cozumAciklamasi", "")
                    //       .Replace("@durum", Incident.INCIDENT_STATUS != null ? Incident.INCIDENT_STATUS.MAIN_DATA_NAME : "")
                    //       .Replace("@kod", Incident.CODE);


                    //    if (emailTemplate.TO_CREATED_USER != null)
                    //    {
                    //        MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                    //        {
                    //            CREATED_DATE = DateTime.Now,
                    //            CREATED_USER_ID = incident.UPDATED_USER_ID,
                    //            IS_DELETED = false,
                    //            IS_SENT = false,
                    //            TO_ADDRESS = Incident.CREATED_USER.EMAIL,
                    //            MAIL_SUBJECT = subject,
                    //            MAIL_BODY = body,
                    //            MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                    //        };
                    //        context.MAIL_TO_SEND.Add(mailToSend);
                    //        context.SaveChanges();
                    //    }
                    //    if (emailTemplate.TO_ASSIGNED_USER != null)
                    //    {
                    //        MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                    //        {
                    //            CREATED_DATE = DateTime.Now,
                    //            CREATED_USER_ID = incident.UPDATED_USER_ID,
                    //            IS_DELETED = false,
                    //            IS_SENT = false,
                    //            TO_ADDRESS = Incident.ASSIGNED_USER.EMAIL,
                    //            MAIL_SUBJECT = subject,
                    //            MAIL_BODY = body,
                    //            MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                    //        };
                    //        context.MAIL_TO_SEND.Add(mailToSend);
                    //        context.SaveChanges();
                    //    }
                    //    if (emailTemplate.TO_ASSIGNED_GROUP_USER != null)
                    //    {
                    //        var groupExpert = context.GROUP_EXPERT.Where(q => q.GROUP_ID == Incident.ASSIGNED_GROUP_ID).ToList();
                    //        if (groupExpert != null)
                    //        {
                    //            foreach (var item in groupExpert)
                    //            {
                    //                MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                    //                {
                    //                    CREATED_DATE = DateTime.Now,
                    //                    CREATED_USER_ID = incident.UPDATED_USER_ID,
                    //                    IS_DELETED = false,
                    //                    IS_SENT = false,
                    //                    TO_ADDRESS = item.EXPERT_EMAIL,
                    //                    MAIL_SUBJECT = subject,
                    //                    MAIL_BODY = body,
                    //                    MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                    //                };
                    //                context.MAIL_TO_SEND.Add(mailToSend);
                    //                context.SaveChanges();
                    //            }
                    //        }

                    //    }
                    //    if (!String.IsNullOrEmpty(emailTemplate.TO_USERS))
                    //    {
                    //        int userId = 0;
                    //        var userIdList = emailTemplate.TO_USERS.Split(",");
                    //        for (int i = 0; i < userIdList.Length; i++)
                    //        {
                    //            userId = Convert.ToInt32(userIdList[i]);
                    //            var user = context.USER.FirstOrDefault(q => q.USER_ID == userId);
                    //            MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                    //            {
                    //                CREATED_DATE = DateTime.Now,
                    //                CREATED_USER_ID = incident.UPDATED_USER_ID,
                    //                IS_DELETED = false,
                    //                IS_SENT = false,
                    //                TO_ADDRESS = user.EMAIL,
                    //                MAIL_SUBJECT = subject,
                    //                MAIL_BODY = body,
                    //                MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                    //            };
                    //            context.MAIL_TO_SEND.Add(mailToSend);
                    //            context.SaveChanges();
                    //        }
                    //    }
                    //    if (emailTemplate.TO_GROUPS != null)
                    //    {
                    //        var groupList = emailTemplate.TO_GROUPS.Split(",");
                    //        for (int i = 0; i < groupList.Length; i++)
                    //        {
                    //            MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                    //            {
                    //                CREATED_DATE = DateTime.Now,
                    //                CREATED_USER_ID = incident.UPDATED_USER_ID,
                    //                IS_DELETED = false,
                    //                IS_SENT = false,
                    //                TO_ADDRESS = groupList[i],
                    //                MAIL_SUBJECT = subject,
                    //                MAIL_BODY = body,
                    //                MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                    //            };
                    //            context.MAIL_TO_SEND.Add(mailToSend);
                    //            context.SaveChanges();
                    //        }
                    //    }

                    //}



                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool DeleteIncident(int Id)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var incident = context.INCIDENT.FirstOrDefault(q => q.ID == Id);
                    incident.IS_DELETED = true;
                    context.Entry(incident).State = EntityState.Modified;
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public string MaxCode()
        {
            string code = "AR-";
            using (MesContext context = new MesContext())
            {
                var incidentCode = context.INCIDENT.Max(q => q.CODE);
                if (!String.IsNullOrEmpty(incidentCode))
                {
                    int codeNum = Convert.ToInt32(incidentCode.Split("-")[1]);
                    codeNum += 1;
                    int codeNumLength = codeNum.ToString().Length;
                    for (int i = 0; i < (5 - codeNumLength); i++)
                    {
                        code += "0";
                    }
                    code += codeNum.ToString();
                }
                else
                {
                    code += "00001";
                }
            }
            return code;
        }
        public bool InsertIncidentFiles(INCIDENT_FILES incidentFile)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    context.INCIDENT_FILES.Add(incidentFile);
                    context.SaveChanges();
                    returnVal = true;
                }
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public INCIDENT_TYPE GetIncidentType(string code)
        {
            using (MesContext context = new MesContext())
            {
                var incidentType = context.INCIDENT_TYPE.FirstOrDefault(q => q.CODE == code);
                return incidentType;
            }
        }
        public List<PARAMETER> IncidentStatusList()
        {
            using (MesContext context = new MesContext())
            {
                var incidentStatusList = context.PARAMETER.Include(q => q.PARAMETER_TYPE)
                                                          .Where(q => q.IS_DELETED == false && q.IS_ACTIVE == true && q.PARAMETER_TYPE.CODE == "INCIDENT_STATUS")
                                                          .ToList();
                return incidentStatusList;
            }
        }
        public bool UpdateIncidentStatus(INCIDENT_HISTORY incidentHistory)
        {
            bool returnVal = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (MesContext context = new MesContext())
                    {
                        INCIDENT_HISTORY history = new INCIDENT_HISTORY()
                        {
                            DESCRIPTION = incidentHistory.DESCRIPTION,
                            CREATED_USER_ID = incidentHistory.UPDATED_USER_ID,
                            CREATED_DATE = DateTime.Now,
                            VISIBLE_TO_OPERATOR = incidentHistory.VISIBLE_TO_OPERATOR,
                            VISIBLE_TO_USER = incidentHistory.VISIBLE_TO_USER,
                            INCIDENT_STATUS_ID = incidentHistory.INCIDENT_STATUS_ID,
                            CODE = incidentHistory.CODE,
                            ASSIGNED_GROUP_ID = incidentHistory.ASSIGNED_GROUP_ID,
                            ASSIGNED_USER_ID = incidentHistory.ASSIGNED_USER_ID,
                            INCIDENT_ID = incidentHistory.INCIDENT_ID
                        };

                        context.INCIDENT_HISTORY.Add(history);
                        context.SaveChanges();

                        var Incident = context.INCIDENT.Include(q => q.CREATED_USER)
                                                       .Include(q => q.ASSIGNED_USER)
                                                       .Include(q => q.INCIDENT_STATUS)
                                                       .Include(q => q.CATEGORY)
                                                       .Include(q => q.SUB_CATEGORY)
                                                       .Include(q => q.INCIDENT_PRIORITY)
                                                       .Include(q => q.INCIDENT_IMPACT)
                                                       .Include(q => q.ASSIGNED_GROUP)
                                                       .Include(q => q.ASSIGNED_USER)
                                                       .Include(q => q.INCIDENT_SOURCE)
                                                       .Include(q => q.INCIDENT_TYPE)
                                                       .Include(q => q.SERVICE_CATALOG)
                                                       .FirstOrDefault(q => q.ID == incidentHistory.INCIDENT_ID);
                        if (Incident != null)
                        {
                            if (Incident.INCIDENT_STATUS_ID != incidentHistory.INCIDENT_STATUS_ID)
                            {
                            }


                            Incident.INCIDENT_STATUS_ID = Convert.ToInt32(incidentHistory.INCIDENT_STATUS_ID);
                            Incident.ASSIGNED_GROUP_ID = incidentHistory.ASSIGNED_GROUP_ID == 0 ? null : incidentHistory.ASSIGNED_GROUP_ID;
                            Incident.ASSIGNED_USER_ID = incidentHistory.ASSIGNED_USER_ID == 0 ? null : incidentHistory.ASSIGNED_USER_ID;

                            Incident.UPDATED_DATE = DateTime.Now;
                            Incident.UPDATED_USER_ID = incidentHistory.UPDATED_USER_ID;
                        }
                        context.Entry(Incident).State = EntityState.Modified;
                        context.SaveChanges();
                        returnVal = true;
                    }
                    scope.Complete();
                }
                returnVal = true;
            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool SendMailAndSurvey(INCIDENT incident)
        {
            bool returnVal = false;
            try
            {
                using (MesContext context = new MesContext())
                {
                    var emailTemplate = context.EMAIL_TEMPLATE.FirstOrDefault(q => q.IS_DELETED == false && q.MAIN_PROCESS_STATUS_ID == incident.INCIDENT_STATUS_ID);
                    if (emailTemplate != null)
                    {
                        string body = emailTemplate.BODY.Replace("@adSoyad", incident.CREATED_USER.NAME + " " + incident.CREATED_USER.SURNAME)
                                                        .Replace("@bildirilenAciliyet", incident.INCIDENT_PRIORITY != null ? incident.INCIDENT_PRIORITY.MAIN_DATA_NAME : "")
                                                        .Replace("@konu", incident.SUBJECT)
                                                        .Replace("@aciklama", incident.DESCRIPTION)
                                                        .Replace("@tarih", incident.CREATED_DATE.ToString())
                                                        .Replace("@hizmet", incident.SERVICE_CATALOG != null ? incident.SERVICE_CATALOG.SERVICE_NAME : "")
                                                        .Replace("@kategori", incident.CATEGORY != null ? incident.CATEGORY.MAIN_DATA_NAME : "")
                                                        .Replace("@altKategori", incident.SUB_CATEGORY != null ? incident.SUB_CATEGORY.MAIN_DATA_NAME : "")
                                                        .Replace("@etki", incident.INCIDENT_IMPACT != null ? incident.INCIDENT_IMPACT.MAIN_DATA_NAME : "")
                                                        .Replace("@sorunTipi", incident.INCIDENT_TYPE != null ? incident.INCIDENT_TYPE.MAIN_DATA_NAME : "")
                                                        .Replace("@sorunBildirimKaynagi", incident.INCIDENT_SOURCE != null ? incident.INCIDENT_SOURCE.MAIN_DATA_NAME : "")
                                                        .Replace("@iliskiliVarlik", "")
                                                        .Replace("@atananGrup", incident.ASSIGNED_GROUP != null ? incident.ASSIGNED_GROUP.GROUP_NAME : "")
                                                        .Replace("@atananKisi", incident.ASSIGNED_USER != null ? incident.ASSIGNED_USER.NAME + " " + incident.ASSIGNED_USER.SURNAME : "")
                                                        .Replace("@cozumKodu", "")
                                                        .Replace("@cozumAciklamasi", "")
                                                        .Replace("@durum", incident.INCIDENT_STATUS != null ? incident.INCIDENT_STATUS.MAIN_DATA_NAME : "")
                                                        .Replace("@kod", incident.CODE);


                        string subject = emailTemplate.SUBJECT.Replace("@adSoyad", incident.CREATED_USER.NAME + " " + incident.CREATED_USER.SURNAME)
                                                              .Replace("@bildirilenAciliyet", incident.INCIDENT_PRIORITY != null ? incident.INCIDENT_PRIORITY.MAIN_DATA_NAME : "")
                                                              .Replace("@konu", incident.SUBJECT)
                                                              .Replace("@aciklama", incident.DESCRIPTION)
                                                              .Replace("@tarih", incident.CREATED_DATE.ToString())
                                                              .Replace("@hizmet", incident.SERVICE_CATALOG != null ? incident.SERVICE_CATALOG.SERVICE_NAME : "")
                                                              .Replace("@kategori", incident.CATEGORY != null ? incident.CATEGORY.MAIN_DATA_NAME : "")
                                                              .Replace("@altKategori", incident.SUB_CATEGORY != null ? incident.SUB_CATEGORY.MAIN_DATA_NAME : "")
                                                              .Replace("@etki", incident.INCIDENT_IMPACT != null ? incident.INCIDENT_IMPACT.MAIN_DATA_NAME : "")
                                                              .Replace("@sorunTipi", incident.INCIDENT_TYPE != null ? incident.INCIDENT_TYPE.MAIN_DATA_NAME : "")
                                                              .Replace("@sorunBildirimKaynagi", incident.INCIDENT_SOURCE != null ? incident.INCIDENT_SOURCE.MAIN_DATA_NAME : "")
                                                              .Replace("@iliskiliVarlik", "")
                                                              .Replace("@atananGrup", incident.ASSIGNED_GROUP != null ? incident.ASSIGNED_GROUP.GROUP_NAME : "")
                                                              .Replace("@atananKisi", incident.ASSIGNED_USER != null ? incident.ASSIGNED_USER.NAME + " " + incident.ASSIGNED_USER.SURNAME : "")
                                                              .Replace("@cozumKodu", "")
                                                              .Replace("@cozumAciklamasi", "")
                                                              .Replace("@durum", incident.INCIDENT_STATUS != null ? incident.INCIDENT_STATUS.MAIN_DATA_NAME : "")
                                                              .Replace("@kod", incident.CODE);


                        if (emailTemplate.TO_CREATED_USER != null)
                        {
                            if (incident.CREATED_USER != null)
                            {
                                MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                {
                                    CREATED_DATE = DateTime.Now,
                                    CREATED_USER_ID = incident.UPDATED_USER_ID,
                                    IS_DELETED = false,
                                    IS_SENT = false,
                                    TO_ADDRESS = incident.CREATED_USER.EMAIL,
                                    MAIL_SUBJECT = subject,
                                    MAIL_BODY = body,
                                    MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                };
                                context.MAIL_TO_SEND.Add(mailToSend);
                                context.SaveChanges();
                            }
                        }
                        if (emailTemplate.TO_ASSIGNED_USER != null)
                        {
                            if (incident.ASSIGNED_USER != null)
                            {
                                MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                {
                                    CREATED_DATE = DateTime.Now,
                                    CREATED_USER_ID = incident.UPDATED_USER_ID,
                                    IS_DELETED = false,
                                    IS_SENT = false,
                                    TO_ADDRESS = incident.ASSIGNED_USER.EMAIL,
                                    MAIL_SUBJECT = subject,
                                    MAIL_BODY = body,
                                    MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                };
                                context.MAIL_TO_SEND.Add(mailToSend);
                                context.SaveChanges();
                            }

                        }
                        if (emailTemplate.TO_ASSIGNED_GROUP_USER != null)
                        {
                            var groupExpert = context.GROUP_EXPERT.Where(q => q.GROUP_ID == incident.ASSIGNED_GROUP_ID).ToList();
                            if (groupExpert != null)
                            {
                                foreach (var item in groupExpert)
                                {
                                    if (!String.IsNullOrEmpty(item.EXPERT_EMAIL))
                                    {
                                        MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                        {
                                            CREATED_DATE = DateTime.Now,
                                            CREATED_USER_ID = incident.UPDATED_USER_ID,
                                            IS_DELETED = false,
                                            IS_SENT = false,
                                            TO_ADDRESS = item.EXPERT_EMAIL,
                                            MAIL_SUBJECT = subject,
                                            MAIL_BODY = body,
                                            MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                        };
                                        context.MAIL_TO_SEND.Add(mailToSend);
                                        context.SaveChanges();
                                    }
                                }
                            }

                        }
                        if (!String.IsNullOrEmpty(emailTemplate.TO_USERS))
                        {
                            int userId = 0;
                            var userIdList = emailTemplate.TO_USERS.Split(",");
                            for (int i = 0; i < userIdList.Length; i++)
                            {
                                userId = Convert.ToInt32(userIdList[i]);
                                var user = context.USER.FirstOrDefault(q => q.USER_ID == userId);
                                MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                {
                                    CREATED_DATE = DateTime.Now,
                                    CREATED_USER_ID = incident.UPDATED_USER_ID,
                                    IS_DELETED = false,
                                    IS_SENT = false,
                                    TO_ADDRESS = user.EMAIL,
                                    MAIL_SUBJECT = subject,
                                    MAIL_BODY = body,
                                    MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                };
                                context.MAIL_TO_SEND.Add(mailToSend);
                                context.SaveChanges();
                            }
                        }
                        if (!String.IsNullOrEmpty(emailTemplate.TO_GROUPS))
                        {
                            var groupList = emailTemplate.TO_GROUPS.Split(",");
                            for (int i = 0; i < groupList.Length; i++)
                            {
                                var groupId = Convert.ToInt32(groupList[i]);

                                var group = context.GROUP.FirstOrDefault(q => q.ID == groupId);
                                var userList = context.USER.Where(q => q.USER_GROUP_ID == group.ID).ToList();
                                foreach (var item in userList)
                                {
                                    MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                    {
                                        CREATED_DATE = DateTime.Now,
                                        CREATED_USER_ID = incident.UPDATED_USER_ID,
                                        IS_DELETED = false,
                                        IS_SENT = false,
                                        TO_ADDRESS = item.EMAIL,
                                        MAIL_SUBJECT = subject,
                                        MAIL_BODY = body,
                                        MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                    };
                                    context.MAIL_TO_SEND.Add(mailToSend);
                                    context.SaveChanges();
                                }
                            }
                        }
                    }

                    var survey = context.SURVEY.FirstOrDefault(q => q.IS_DELETED == false && q.SURVEY_PARAMETER_ID == incident.INCIDENT_STATUS_ID);
                    if (survey != null)
                    {
                        string[] usersArray = null;
                        string[] groupsArray = null;

                        string body = "";

                        if (!String.IsNullOrEmpty(survey.TO_USERS))
                        {
                            usersArray = survey.TO_USERS.Split(',');
                        }
                        if (!String.IsNullOrEmpty(survey.TO_GROUPS))
                        {
                            groupsArray = survey.TO_GROUPS.Split(',');
                        }


                        if (groupsArray != null)
                        {
                            for (int i = 0; i < groupsArray.Length; i++)
                            {
                                var groupId = Convert.ToInt32(groupsArray[i]);
                                var userlist = context.USER.Where(q => q.USER_GROUP_ID == groupId);
                                foreach (var item in userlist)
                                {
                                    body = "";
                                    var userId = Convert.ToInt32(item.USER_ID);
                                    SURVEY_HISTORY sh = new SURVEY_HISTORY()
                                    {
                                        CREATED_DATE = DateTime.Now,
                                        IS_DELETED = false,
                                        SURVEY_ID = survey.SURVEY_ID,
                                        UNIQUE_ID = Guid.NewGuid(),
                                        USER_ID = userId
                                    };

                                    context.SURVEY_HISTORY.Add(sh);
                                    context.SaveChanges();


                                    body += "<p>Merhaba,</p><br /><br />";
                                    body += "<p>Aşağıdaki linkten anketimize katılabilirsiniz.</p><br /><br />";
                                    body += "<a href='http://dev.mes-it.com/Surveys/Index?id=";
                                    body += sh.UNIQUE_ID;
                                    body += "'>Ankete Katıl</a>";

                                    MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                    {
                                        CREATED_DATE = DateTime.Now,
                                        CREATED_USER_ID = incident.UPDATED_USER_ID,
                                        IS_DELETED = false,
                                        IS_SENT = false,
                                        TO_ADDRESS = item.EMAIL,
                                        MAIL_SUBJECT = survey.SURVEY_NAME,
                                        MAIL_BODY = body,
                                        MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                    };
                                    context.MAIL_TO_SEND.Add(mailToSend);
                                    context.SaveChanges();



                                }
                            }
                        }

                        if (usersArray != null)
                        {
                            for (int i = 0; i < usersArray.Length; i++)
                            {
                                body = "";
                                var userId = Convert.ToInt32(usersArray[i]);
                                var getUser = context.USER.FirstOrDefault(q => q.USER_ID == userId);
                                SURVEY_HISTORY sh = new SURVEY_HISTORY()
                                {
                                    CREATED_DATE = DateTime.Now,
                                    IS_DELETED = false,
                                    SURVEY_ID = survey.SURVEY_ID,
                                    UNIQUE_ID = Guid.NewGuid(),
                                    USER_ID = userId
                                };

                                context.SURVEY_HISTORY.Add(sh);
                                context.SaveChanges();

                                body += "<p>Merhaba,</p><br /><br />";
                                body += "<p>Aşağıdaki linkten anketimize katılabilirsiniz.</p><br /><br />";
                                body += "<a href='http://dev.mes-it.com/Surveys/Index?id=";
                                body += sh.UNIQUE_ID;
                                body += "'>Ankete Katıl</a>";

                                MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                {
                                    CREATED_DATE = DateTime.Now,
                                    CREATED_USER_ID = incident.UPDATED_USER_ID,
                                    IS_DELETED = false,
                                    IS_SENT = false,
                                    TO_ADDRESS = getUser.EMAIL,
                                    MAIL_SUBJECT = survey.SURVEY_NAME,
                                    MAIL_BODY = body,
                                    MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                };
                                context.MAIL_TO_SEND.Add(mailToSend);
                                context.SaveChanges();

                            }
                        }


                        if (survey.TO_CREATED_USER != null)
                        {
                            if (incident.CREATED_USER != null)
                            {
                                body = "";
                                SURVEY_HISTORY sh = new SURVEY_HISTORY()
                                {
                                    CREATED_DATE = DateTime.Now,
                                    IS_DELETED = false,
                                    SURVEY_ID = survey.SURVEY_ID,
                                    UNIQUE_ID = Guid.NewGuid(),
                                    USER_ID = Convert.ToInt32(incident.CREATED_USER_ID)
                                };

                                context.SURVEY_HISTORY.Add(sh);
                                context.SaveChanges();

                                body += "<p>Merhaba,</p><br /><br />";
                                body += "<p>Aşağıdaki linkten anketimize katılabilirsiniz.</p><br /><br />";
                                body += "<a href='http://dev.mes-it.com/Surveys/Index?id=";
                                body += sh.UNIQUE_ID;
                                body += "'>Ankete Katıl</a>";

                                MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                {
                                    CREATED_DATE = DateTime.Now,
                                    CREATED_USER_ID = incident.UPDATED_USER_ID,
                                    IS_DELETED = false,
                                    IS_SENT = false,
                                    TO_ADDRESS = incident.CREATED_USER.EMAIL,
                                    MAIL_SUBJECT = survey.SURVEY_NAME,
                                    MAIL_BODY = body,
                                    MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                };
                                context.MAIL_TO_SEND.Add(mailToSend);
                                context.SaveChanges();
                            }
                        }


                        if (survey.TO_ASSIGNED_USER != null)
                        {
                            if (incident.ASSIGNED_USER != null)
                            {
                                body = "";
                                SURVEY_HISTORY sh = new SURVEY_HISTORY()
                                {
                                    CREATED_DATE = DateTime.Now,
                                    IS_DELETED = false,
                                    SURVEY_ID = survey.SURVEY_ID,
                                    UNIQUE_ID = Guid.NewGuid(),
                                    USER_ID = Convert.ToInt32(incident.ASSIGNED_USER_ID)
                                };

                                context.SURVEY_HISTORY.Add(sh);
                                context.SaveChanges();

                                body += "<p>Merhaba,</p><br /><br />";
                                body += "<p>Aşağıdaki linkten anketimize katılabilirsiniz.</p><br /><br />";
                                body += "<a href='http://dev.mes-it.com/Surveys/Index?id=";
                                body += sh.UNIQUE_ID;
                                body += "'>Ankete Katıl</a>";

                                MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                {
                                    CREATED_DATE = DateTime.Now,
                                    CREATED_USER_ID = incident.UPDATED_USER_ID,
                                    IS_DELETED = false,
                                    IS_SENT = false,
                                    TO_ADDRESS = incident.ASSIGNED_USER.EMAIL,
                                    MAIL_SUBJECT = survey.SURVEY_NAME,
                                    MAIL_BODY = body,
                                    MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                };
                                context.MAIL_TO_SEND.Add(mailToSend);
                                context.SaveChanges();
                            }
                        }

                        if (survey.TO_ASSIGNED_GROUP_USER != null)
                        {
                            if (incident.ASSIGNED_GROUP != null)
                            {
                                body = "";
                                var groupId = Convert.ToInt32(incident.ASSIGNED_GROUP_ID);
                                var userList = context.USER.Where(q => q.USER_GROUP_ID == groupId).ToList();
                                if (userList != null)
                                {
                                    foreach (var item in userList)
                                    {
                                        SURVEY_HISTORY sh = new SURVEY_HISTORY()
                                        {
                                            CREATED_DATE = DateTime.Now,
                                            IS_DELETED = false,
                                            SURVEY_ID = survey.SURVEY_ID,
                                            UNIQUE_ID = Guid.NewGuid(),
                                            USER_ID = item.USER_ID
                                        };

                                        context.SURVEY_HISTORY.Add(sh);
                                        context.SaveChanges();

                                        body += "<p>Merhaba,</p><br /><br />";
                                        body += "<p>Aşağıdaki linkten anketimize katılabilirsiniz.</p><br /><br />";
                                        body += "<a href='http://dev.mes-it.com/Surveys/Index?id=";
                                        body += sh.UNIQUE_ID;
                                        body += "'>Ankete Katıl</a>";

                                        MAIL_TO_SEND mailToSend = new MAIL_TO_SEND()
                                        {
                                            CREATED_DATE = DateTime.Now,
                                            CREATED_USER_ID = incident.UPDATED_USER_ID,
                                            IS_DELETED = false,
                                            IS_SENT = false,
                                            TO_ADDRESS = item.EMAIL,
                                            MAIL_SUBJECT = survey.SURVEY_NAME,
                                            MAIL_BODY = body,
                                            MAIN_PROCESS_ID = emailTemplate.MAIN_PROCESS_ID
                                        };
                                        context.MAIL_TO_SEND.Add(mailToSend);
                                        context.SaveChanges();
                                    }
                                }

                            }
                        }

                    }



                }

                returnVal = true;

            }
            catch (Exception ex)
            {
            }

            return returnVal;
        }
        public bool IncidentConfirmAndClose(int incidentId, int userId)
        {
            bool returnVal = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (MesContext context = new MesContext())
                    {
                        var incidentResolution = context.INCIDENT_RESOLUTION.FirstOrDefault(q => q.INCIDENT_ID == incidentId);
                        if (incidentResolution != null)
                        {
                            incidentResolution.IS_APPROVED = true;
                            incidentResolution.UPDATED_DATE = DateTime.Now;
                            incidentResolution.UPDATED_USER_ID = userId;
                        }
                        else
                        {
                            returnVal = false;
                            return returnVal;
                        }
                        context.Entry(incidentResolution).State = EntityState.Modified;
                        context.SaveChanges();

                        var incident = context.INCIDENT.FirstOrDefault(q => q.ID == incidentId);
                        if (incident != null)
                        {
                            incident.INCIDENT_STATUS_ID = 41;
                            incident.UPDATED_DATE = DateTime.Now;
                            incident.UPDATED_USER_ID = userId;
                            context.Entry(incident).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            returnVal = false;
                            return returnVal;
                        }

                        scope.Complete();
                        returnVal = true;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public bool IncidentReject(int incidentId, int userId)
        {
            bool returnVal = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (MesContext context = new MesContext())
                    {
                        var incidentResolution = context.INCIDENT_RESOLUTION.FirstOrDefault(q => q.INCIDENT_ID == incidentId);
                        if (incidentResolution != null)
                        {
                            incidentResolution.IS_APPROVED = false;
                            incidentResolution.UPDATED_DATE = DateTime.Now;
                            incidentResolution.UPDATED_USER_ID = userId;
                        }
                        else
                        {
                            returnVal = false;
                            return returnVal;
                        }
                        context.Entry(incidentResolution).State = EntityState.Modified;
                        context.SaveChanges();

                        var incident = context.INCIDENT.FirstOrDefault(q => q.ID == incidentId);
                        if (incident != null)
                        {
                            incident.INCIDENT_STATUS_ID = 39;
                            incident.UPDATED_DATE = DateTime.Now;
                            incident.UPDATED_USER_ID = userId;
                            context.Entry(incident).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            returnVal = false;
                            return returnVal;
                        }

                        scope.Complete();
                        returnVal = true;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return returnVal;
        }
        public int sumUnResolved() 
        {
            int sum = 0;

            using (MesContext context = new MesContext())
            {
                var count = context.INCIDENT.Where(x => x.INCIDENT_STATUS_ID != 4 && x.INCIDENT_STATUS_ID != 41).Count().ToString();

                sum = Convert.ToInt32(count);
            }

            return sum;
        }
        public int sumOverdue()
        {
            int sum = 0;

            using (MesContext context = new MesContext())
            {
                var count = context.INCIDENT.Where(x => x.INCIDENT_STATUS_ID != 4 && x.INCIDENT_STATUS_ID != 41).Count().ToString();

                sum = Convert.ToInt32(count);
            }

            return sum;
        }
        public int sumDuetoday()
        {
            int sum = 0;

            using (MesContext context = new MesContext())
            {
                var count = context.INCIDENT.Where(x => x.INCIDENT_STATUS_ID != 4 && x.INCIDENT_STATUS_ID != 41).Count().ToString();

                sum = Convert.ToInt32(count);
            }

            return sum;
        }
        public int sumOpen()
        {
            int sum = 0;

            using (MesContext context = new MesContext())
            {
                var count = context.INCIDENT.Where(x => x.INCIDENT_STATUS_ID != 41).Count().ToString();

                sum = Convert.ToInt32(count);
            }

            return sum;
        }
        public int sumOnhold()
        {
            int sum = 0;

            using (MesContext context = new MesContext())
            {
                var count = context.INCIDENT.Where(x => x.INCIDENT_STATUS_ID != 4 && x.INCIDENT_STATUS_ID != 41).Count().ToString();

                sum = Convert.ToInt32(count);
            }

            return sum;
        }
        public int sumUnassigned()
        {
            int sum = 0;

            using (MesContext context = new MesContext())
            {
                var count = context.INCIDENT.Where(x => x.INCIDENT_STATUS_ID == 1).Count().ToString();

                sum = Convert.ToInt32(count);
            }

            return sum;
        }
    }
}
