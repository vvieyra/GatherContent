using GCApi.GatherContent;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCApi.GatherContent
{
    public class GcAssetAccess
    {
        private GatherApi _api = null;
        public GcAssetAccess(GatherApi api) 
        {
            _api = api;
        }
        #region Users
        public JObject GetMe()
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Users_GetMe);
            return null;
        }
        public JObject GetUsers()
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Users_GetUsers);
            return null;
        }
        public JObject GetUser(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Users_GetUser, Id);
            return null;
        }
        #endregion
        #region Companys
        public JObject GetMyCompany()
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Companies_GetMyCompany);
            return null;
        }
        public JObject GetCompanies()
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Companies_GetCompanies);
            return null;
        }
        public JObject GetCompany(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Companies_GetCompany, Id);
            return null;
        }
        #endregion
        #region Projects
        public JObject GetProjects()
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Projects_GetProjects);
            return null;
        }
        public JObject GetProject(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Projects_GetProject, Id);
            return null;
        }
        public JObject GetProjectsByCompany(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Projects_GetProjectsByCompany, Id);
            return null;
        }
        #endregion
        #region Pages
        public JObject GetPages()
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Pages_GetPages);
            return null;
        }
        public JObject GetPage(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Pages_GetPage, Id);
            return null;
        }
        public JObject GetPagesByProject(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Pages_GetPagesByProject, Id);
            return null;
        }
        #endregion
        #region Files
        public JObject GetFiles()
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Files_GetFiles);
            return null;
        }
        public JObject GetFile(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Files_GetFile, Id);
            return null;
        }
        public JObject GetFilesByProject(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Files_GetFilesByProject, Id);
            return null;
        }
        public JObject GetFilesByPage(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Files_GetFilesByPage, Id);
            return null;
        }
        #endregion
        #region Custom States
        public JObject GetCustomStates() 
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Custom_GetCustomStates);
            return null;
        }
        public JObject GetCustomState(string Id)
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Custom_GetCustomState, Id);
            return null;
        }
        public JObject GetCustomStatesByProject(string Id) 
        {
            if (_api != null)
                return _api.GetDataJson(GatherMethods.Custom_GetCustomStatesByProject, Id);
            return null;
        }
        #endregion
    }
}