﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace elFinder.NetCore.Models.Response
{
    [DataContract]
    internal class Archive
    {
        private static string[] empty = new string[0];

        [DataMember(Name = "create")]
        public IEnumerable<string> Create => empty;

        [DataMember(Name = "extract")]
        public IEnumerable<string> Extract => empty;
    }

    [DataContract]
    internal class Options
    {
        private static string[] disabled = new string[] { "extract", "create" };
        private static string[] empty = new string[0];
        private static Archive emptyArchives = new Archive();

        public Options(FullPath fullPath)
        {
            Path = fullPath.Root.Alias;
            if (fullPath.RelativePath != string.Empty)
            {
                Path += Separator + fullPath.RelativePath.Replace('\\', Separator);
            }
            Url = fullPath.Root.Url ?? string.Empty;
            ThumbnailsUrl = fullPath.Root.ThumbnailsUrl ?? string.Empty;
            //ThumbnailsUrl = fullPath.Root.ThumbnailsUrl ?? fullPath.Root.Url + "/.tmb/";
        }

        [DataMember(Name = "archivers")]
        public Archive Archivers => emptyArchives;

        [DataMember(Name = "disabled")]
        public IEnumerable<string> Disabled => disabled;

        [DataMember(Name = "copyOverwrite")]
        public byte IsCopyOverwrite => 1;

        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "separator")]
        public char Separator => '/';

        [DataMember(Name = "tmbUrl")]
        public string ThumbnailsUrl { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}