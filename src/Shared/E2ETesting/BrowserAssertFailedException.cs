// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using Xunit.Sdk;

namespace OpenQA.Selenium
{
    // Used to report errors when we find errors in the browser. This is useful
    // because the underlying assert probably doesn't provide good information in that
    // case.
    public class BrowserAssertFailedException : XunitException
    {
        public BrowserAssertFailedException(IReadOnlyList<LogEntry> logs, Exception innerException, string screenShotPath)
            : base(BuildMessage(logs, screenShotPath), innerException)
        {
        }

        private static string BuildMessage(IReadOnlyList<LogEntry> logs, string screenShotPath) =>
            (File.Exists(screenShotPath) ? $"Screen shot captured at '{screenShotPath}'" + Environment.NewLine : "") +
            (logs.Count > 0 ? "Encountered browser errors" : "No browser errors found") + " while running the assertion." + Environment.NewLine +
            string.Join(Environment.NewLine, logs);
    }
}
