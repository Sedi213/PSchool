﻿namespace WebUI.ResourceModels
{
    public class RequestAddStudent
    {
        public Guid ParentId { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
}
