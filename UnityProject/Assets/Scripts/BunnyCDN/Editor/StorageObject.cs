// MIT License

// Copyright (c) 2019 BunnyWay d.o.o.

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyCDN.Net.Storage.Models
{
    public class StorageObject
    {
        /// <summary>
        /// The unique GUID of the file
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// The ID of the BunnyCDN user that holds the file
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// The date when the file was created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date when the file was last modified
        /// </summary>
        public DateTime LastChanged { get; set; }
        /// <summary>
        /// The name of the storage zone to which the file is linked
        /// </summary>
        public string StorageZoneName { get; set; }
        /// <summary>
        /// The path to the object
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// The name of the object
        /// </summary>
        public string ObjectName { get; set; }
        /// <summary>
        /// The total of the object in bytes
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// True if the object is a directory
        /// </summary>
        public bool IsDirectory { get; set; }
        /// <summary>
        /// The ID of the storage server that the file resides on
        /// </summary>
        public int ServerId { get; set; }
        /// <summary>
        /// The ID of the storage zone that the object is linked to
        /// </summary>
        public long StorageZoneId { get; set; }

        /// <summary>
        /// Gets the full path to the file
        /// </summary>
        public string FullPath
        {
            get
            {
                return this.Path + ObjectName;
            }
        }
    }
}
