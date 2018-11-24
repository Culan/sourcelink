// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Tasks.SourceControl;

namespace Microsoft.SourceLink.BitbucketEnterprise.Git
{
    /// <summary>
    /// The task calculates SourceLink URL for a given SourceRoot.
    /// If the SourceRoot is associated with a git repository with a recognized domain the <see cref="SourceLinkUrl"/>
    /// output property is set to the content URL corresponding to the domain, otherwise it is set to string "N/A".
    /// </summary>
    public sealed class GetSourceLinkUrl : GetSourceLinkUrlGitTask
    {
        protected override string HostsItemGroupName => "SourceLinkBitbucketEnterpriseGitHost";
        protected override string ProviderDisplayName => "BitbucketEnterprise.Git";

        protected override string BuildSourceLinkUrl(Uri contentUri, Uri gitUri, string relativeUrl, string revisionId, ITaskItem hostItem)
        {
            return contentUri.Scheme + "://" + contentUri.Authority + "/" + "projects" + "/" + relativeUrl.Split('/')[relativeUrl.Split('/').Count()-2] + "/repos/" + string.Join("/", relativeUrl.Split('/').Last()) + "/raw/*?at=" + revisionId;
        }
    }
}
