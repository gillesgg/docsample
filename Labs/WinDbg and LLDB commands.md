# Starting
Command | WinDbg | LLDB
--- | --- | ---
Start | `windbg {executable} [{args}]` | `lldb {executable} [--args]`
Attach | `windbg -p {pid}` | `lldb --attach-pid {pid}`

# Symbols and modules
Command | WinDbg | LLDB
--- | --- | ---
(Re)load symbols | `lb {module-name}` | `target symbols add {symbol-file-path}`
List modules | `lm` | `image list`
Dump module information | `lmvm {module-name}` | `image dump [symtab\|sections\|ast\|symfile\|line-table] {module-name}`
Resolve native function address | `x {module-name}!{function} (wildcards accepted)` | `image lookup -vn {function} (-r for Regex search)`
Find nearest symbol | `ln {address}` | `image lookup -va {address}`

# Processes and threads
Command | WinDbg | LLDB
--- | --- | ---
Show processes | `\|` |
Switch to process | `\|{process-num}s` |
List threads | `~` | `thread list`
Select thread | `~{thread-num}s` | `thread select {thread-num}`
Execute on all threads | `~*{command}` |
Enable child process debugging | `.childdbg 1` |

# Program execution
Command | WinDbg | LLDB
--- | --- | ---
Disasemble | `u {address}` | `disasemble [-s {address}] (alias: di)`
Disasemble function | `uf {address}` | `disasemble -n {function-name}`
Continue | `g` | `{thread\|process} continue`
Step out | `gu` | `thread step-out`
Step into | `t` | `thread step-in (s)` `thread step-inst (si)`
Step over | `p` | `thread step-over`
Continue until address | `{g\|t\|p}a {address}` | `thread until -a {address}`

# Breakpoints
Command | WinDbg | LLDB
--- | --- | ---
List breakpoints | `bl` | `break[point] list`
Create breakpoint | `bp {address\|functuion-name} [{command}]` | `break[point] set -a {address}` `break[point] set -n {funtion-name}`
Enable/disable breakpoint | `b{e\|d} {breakpoint-number}` | `break[point] {enable\|disable} {breakpoint-number}`
Delete breakpoint | `bc {breakpoint-number\|*}` | `break[point] delete {breakpoint-number}`
Create data breakpoint | `[~{thread-num}]ba {access}{size}{address} [{command}]` | `watch[point] {address} [-w {access}] [-s {size}]`

# .NET SOS Extension
## Metadata
* `dumpdomain` - dump information about AppDomains
* `dumpmt {address}` - dump a Method Table 
* `dumpclass {address}`
* `dumpmd {address}`
* `name2ee {module}!{type-or-method}` - resolve a class name into MT or a method name into MD

## Manged code breakpoints
* `bpmd {module} {method}` or `bpmd -md {md}` - create a method breakpoint
* `bpmd {source-file}:{line-number}` - create a breakpoint in the source code file
* `bpmd -list` - list pending breakpoints
* `bpmd -clear {breakpoint-number}` - remove a pending breakpoint
* `bpmd -clearall` - remove all pending breakpoints

## Managed heap
* `eeheap [-gc] [-loader]` - show information about the internal CLR memory
* `dumpheap -stat` - show managed heap statistics
* `dumpheap -mt {mt}` or `dumpheap -type {typename}` - dump objects of a specific type
* `dumpobj {address}` - dump a managed object
* `gcroot {address}` - look for reference (or roots) to an object
* `finalizequeue` - show all objects registered for finalization

## Threads and calls stacks
* `!threads` (WinDbg) / `clrthreads` (LLDB) - list all the managed threads
* `clrstack` - show the managed call stack of the current thread
* `dumpstack` - show the complete call stack (native + managed)
* `dso` - dump managed objects referenced in the call stack
* `pe` - show exception details

## IL and assembly
* `dumpil {md}` - dump the IL code of the specified method
* `ip2md {address}` - match the assembly instruction address with MD
* `u {md|address}` - disassembly a method or a code address (with managed metadata annotations)
