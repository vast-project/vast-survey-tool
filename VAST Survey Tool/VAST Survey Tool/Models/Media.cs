using System;
using System.Collections.Generic;

namespace VAST_Survey_Tool.Models.Media
{
        public class About
        {
            public string href { get; set; }
        }

        public class Author
        {
            public bool embeddable { get; set; }
            public string href { get; set; }
        }

        public class Caption
        {
            public string rendered { get; set; }
        }

        public class Collection
        {
            public string href { get; set; }
        }

        public class Description
        {
            public string rendered { get; set; }
        }

        public class Guid
        {
            public string rendered { get; set; }
        }

        public class Links
        {
            public List<Self> self { get; set; }
            public List<Collection> collection { get; set; }
            public List<About> about { get; set; }
            public List<Author> author { get; set; }
            public List<Reply> replies { get; set; }
        }

        public class MediaDetails
        {
            public object width { get; set; }
            public object height { get; set; }
            public Sizes sizes { get; set; }
        }

        public class Meta
        {
            public bool inline_featured_image { get; set; }
        }

        public class Reply
        {
            public bool embeddable { get; set; }
            public string href { get; set; }
        }

        public class Media
        {
            public int id { get; set; }
            public DateTime date { get; set; }
            public DateTime date_gmt { get; set; }
            public Guid guid { get; set; }
            public DateTime modified { get; set; }
            public DateTime modified_gmt { get; set; }
            public string slug { get; set; }
            public string status { get; set; }
            public string type { get; set; }
            public string link { get; set; }
            public Title title { get; set; }
            public int author { get; set; }
            public string comment_status { get; set; }
            public string ping_status { get; set; }
            public string template { get; set; }
            public Meta meta { get; set; }
            public Description description { get; set; }
            public Caption caption { get; set; }
            public string alt_text { get; set; }
            public string media_type { get; set; }
            public string mime_type { get; set; }
            public MediaDetails media_details { get; set; }
            public object post { get; set; }
            public string source_url { get; set; }
            public Links _links { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Sizes
        {
        }

        public class Title
        {
            public string rendered { get; set; }
        }



}