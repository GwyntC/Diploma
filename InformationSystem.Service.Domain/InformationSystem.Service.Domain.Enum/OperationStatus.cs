using System;
using System.Collections.Generic;
using System.Text;

namespace InformationSystem.Service.Domain
{
    /// <summary>
    /// The operation status enum.
    /// </summary>
    public enum OperationStatus
    {
        /// <summary>
        /// The done.
        /// </summary>
        Done = 0x1,

        /// <summary>
        /// The cancelled.
        /// </summary>
        Cancelled = 0x2
    }
}
