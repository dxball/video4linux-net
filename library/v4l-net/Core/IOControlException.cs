using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Video4Linux.Core {

    //http://lxr.free-electrons.com/source/include/uapi/asm-generic/errno-base.h#L12
    public enum IOErrors {
        NONE        = 0,      // 
        EPERM       = 1,      // Operation not permitted
        ENOENT      = 2,      // No such file or directory
        ESRCH       = 3,      // No such process
        EINTR       = 4,      // Interrupted system call
        EIO         = 5,      // I/O error
        ENXIO       = 6,      // No such device or address
        E2BIG       = 7,      // Argument list too long
        ENOEXEC     = 8,      // Exec format error
        EBADF       = 9,      // Bad file number
        ECHILD      = 10,     // No child processes
        EAGAIN      = 11,     // Try again
        ENOMEM      = 12,     // Out of memory
        EACCES      = 13,     // Permission denied
        EFAULT      = 14,     // Bad address
        ENOTBLK     = 15,     // Block device required
        EBUSY       = 16,     // Device or resource busy
        EEXIST      = 17,     // File exists
        EXDEV       = 18,     // Cross-device link
        ENODEV      = 19,     // No such device
        ENOTDIR     = 20,     // Not a directory
        EISDIR      = 21,     // Is a directory
        EINVAL      = 22,     // Invalid argument
        ENFILE      = 23,     // File table overflow
        EMFILE      = 24,     // Too many open files
        ENOTTY      = 25,     // Not a typewriter
        ETXTBSY     = 26,     // Text file busy
        EFBIG       = 27,     // File too large
        ENOSPC      = 28,     // No space left on device
        ESPIPE      = 29,     // Illegal seek
        EROFS       = 30,     // Read-only file system
        EMLINK      = 31,     // Too many links
        EPIPE       = 32,     // Broken pipe
        EDOM        = 33,     // Math argument out of domain of func
        ERANGE      = 34,     // Math result not representable
    }

    public class IOControlException : Exception {
        public Int32 ErrorCode { get; private set; }
        public IOErrors Error {
            get {
                if(this.Error >= 0) {
                    return IOErrors.NONE;
                } else {
                    return (IOErrors)(-this.ErrorCode);
                }
            }
        }

        private String customMessage = null;
        private String errorMessage = null;

        public IOControlException(Int32 erroCode)
            : base() {
            this.ErrorCode = ErrorCode;
        }

        public IOControlException(String message, Int32 errorCode) {
            if(message != null) {
                this.customMessage = message.Trim();
            }
        }

        public override string Message {
            get {
                if(this.errorMessage == null) {
                    switch(this.Error) {
                    case IOErrors.NONE: this.errorMessage = "No Error"; break;
                    case IOErrors.EPERM: this.errorMessage = "Operation not permitted"; break;
                    case IOErrors.ENOENT: this.errorMessage = "No such file or directory"; break;
                    case IOErrors.ESRCH: this.errorMessage = "No such process"; break;
                    case IOErrors.EINTR: this.errorMessage = "Interrupted system call"; break;
                    case IOErrors.EIO: this.errorMessage = "I/O error"; break;
                    case IOErrors.ENXIO: this.errorMessage = "No such device or address"; break;
                    case IOErrors.E2BIG: this.errorMessage = "Argument list too long"; break;
                    case IOErrors.ENOEXEC: this.errorMessage = "Exec format error"; break;
                    case IOErrors.EBADF: this.errorMessage = "Bad file number"; break;
                    case IOErrors.ECHILD: this.errorMessage = "No child processes"; break;
                    case IOErrors.EAGAIN: this.errorMessage = "Try again"; break;
                    case IOErrors.ENOMEM: this.errorMessage = "Out of memory"; break;
                    case IOErrors.EACCES: this.errorMessage = "Permission denied"; break;
                    case IOErrors.EFAULT: this.errorMessage = "Bad address"; break;
                    case IOErrors.ENOTBLK: this.errorMessage = "Block device required"; break;
                    case IOErrors.EBUSY: this.errorMessage = "Device or resource busy"; break;
                    case IOErrors.EEXIST: this.errorMessage = "File exists"; break;
                    case IOErrors.EXDEV: this.errorMessage = "Cross-device link"; break;
                    case IOErrors.ENODEV: this.errorMessage = "No such device"; break;
                    case IOErrors.ENOTDIR: this.errorMessage = "Not a directory"; break;
                    case IOErrors.EISDIR: this.errorMessage = "Is a directory"; break;
                    case IOErrors.EINVAL: this.errorMessage = "Invalid argument"; break;
                    case IOErrors.ENFILE: this.errorMessage = "File table overflow"; break;
                    case IOErrors.EMFILE: this.errorMessage = "Too many open files"; break;
                    case IOErrors.ENOTTY: this.errorMessage = "Not a typewriter"; break;
                    case IOErrors.ETXTBSY: this.errorMessage = "Text file busy"; break;
                    case IOErrors.EFBIG: this.errorMessage = "File too large"; break;
                    case IOErrors.ENOSPC: this.errorMessage = "No space left on device"; break;
                    case IOErrors.ESPIPE: this.errorMessage = "Illegal seek"; break;
                    case IOErrors.EROFS: this.errorMessage = "Read-only file system"; break;
                    case IOErrors.EMLINK: this.errorMessage = "Too many links"; break;
                    case IOErrors.EPIPE: this.errorMessage = "Broken pipe"; break;
                    case IOErrors.EDOM: this.errorMessage = "Math argument out of domain of func"; break;
                    case IOErrors.ERANGE: this.errorMessage = "Math result not representable"; break;
                    }
                }
                if(String.IsNullOrEmpty(this.customMessage)) {
                    return this.errorMessage;
                } else {
                    return this.customMessage + ":" + this.errorMessage;
                }
            }
        }
    }
}
