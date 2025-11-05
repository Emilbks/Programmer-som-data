.method public hidebysig static 
		void SelectionSort (
			int32[] arr // arr is argument 0 (arg.0)
		) cil managed 
	{
		// ... (Header info)
		.maxstack 4
		.locals init (
			[0] int32, // i
			[1] int32, // least
			[2] int32, // tmp
			[3] int32, // j
			[4] bool,  // Temp for (arr[j] < arr[least])
			[5] bool,  // Temp for (j < arr.Length)
			[6] bool   // Temp for (i < arr.Length)
		)

		IL_0000: nop                          // No operation
		// Outer Loop (for (int i = 0; i < arr.Length; i++))
		IL_0001: ldc.i4.0                     // Push 0 onto the stack
		IL_0002: stloc.0                      // Pop 0, store as local 0 (i = 0)
		IL_0003: br.s IL_0041                 // Jump to the loop condition (IL_0041)
		// loop start (head: IL_0041)
			IL_0005: nop                      // No operation
			
			// least = i;
			IL_0006: ldloc.0                  // Load local variable 0 (i) and Push to stack
			IL_0007: stloc.1                  // Pop 0 (i) and Store as local 1 (least = i)
			
			// j = i + 1;
			IL_0008: ldloc.0                  // Push i (local 0)
			IL_0009: ldc.i4.1                 // Push 1
			IL_000a: add                      // Pop i, pop 1, push i + 1
			IL_000b: stloc.3                  // Pop result of add from stack and store as local 3 (j = i + 1)
			IL_000c: br.s IL_0022             // Jump to the inner loop condition (IL_0022)
			
			// Inner Loop (for (int j = i+1; j < arr.Length; j++))
			// loop start (head: IL_0022)
				// if (arr[j] < arr[least])
				IL_000e: ldarg.0              // Push arr reference
				IL_000f: ldloc.3              // Push j (local 3)
				IL_0010: ldelem.i4            // Pop arr, pop j, push value of arr[j]
				IL_0011: ldarg.0              // Push arr reference
				IL_0012: ldloc.1              // Push least (local 1)
				IL_0013: ldelem.i4            // Pop arr, pop least, push value of arr[least]
				IL_0014: clt                  // Pop arr[least], pop arr[j], push 1 if arr[j] < arr[least], 0 otherwise
				IL_0016: stloc.s 4            // Pop result of comparison, store bool result as local 4
				IL_0018: ldloc.s 4            // Push bool result (local 4, 1 = true & 0 = false)
				IL_001a: brfalse.s IL_001e    // If 0 (arr[j] >= arr[least]), jump to IL_001e (skip least = j), pop bool result

				// least = j;
				IL_001c: ldloc.3                  // Push j
				IL_001d: stloc.1                  // Pop j, store as local 1 (least = j)

				// j++
				IL_001e: ldloc.3                  // Push j
				IL_001f: ldc.i4.1                 // Push 1
				IL_0020: add                      // Pop j, pop 1, push j + 1
				IL_0021: stloc.3                  // Pop, store as local 3 (j++)

				// Inner Loop Condition (j < arr.Length)
				IL_0022: ldloc.3                  // Push j
				IL_0023: ldarg.0                  // Push arr reference
				IL_0024: ldlen                    // Pop arr, push array length (unsigned int)
				IL_0025: conv.i4                  // Convert length to signed 32-bit int
				IL_0026: clt                      // Pop length, pop j, push 1 if j < length, 0 otherwise
				IL_0028: stloc.s 5                // Pop bool int value, store bool result as local 5
				IL_002a: ldloc.s 5                // Push bool result
				IL_002c: brtrue.s IL_000e         // If 1 (j < arr.Length), jump back to loop body (IL_000e), pop bool result
			// end inner loop

			// Swap: int tmp = arr[i]; arr[i] = arr[least]; arr[least] = tmp;
			
			// tmp = arr[i]
			IL_002e: ldarg.0                  // Push arr reference
			IL_002f: ldloc.0                  // Push i
			IL_0030: ldelem.i4                // Pop arr, pop i, pushvalue of arr[i]
			IL_0031: stloc.2                  // Pop arr[i], store as local 2 (tmp = arr[i])
			
			// arr[i] = arr[least]
			IL_0032: ldarg.0                  // Push arr reference
			IL_0033: ldloc.0                  // Push i
			IL_0034: ldarg.0                  // Push arr reference
			IL_0035: ldloc.1                  // Push least
			IL_0036: ldelem.i4                // Pop arr, pop least, push value of arr[least]
			IL_0037: stelem.i4                // Pop arr[least], pop i, pop arr (arr[i] = arr[least])
			
			// arr[least] = tmp
			IL_0038: ldarg.0                  // Push arr reference
			IL_0039: ldloc.1                  // Push least
			IL_003a: ldloc.2                  // Push tmp (local 2)
			IL_003b: stelem.i4                // Pop value, pop least, pop arr (arr[least] = tmp)
			
			IL_003c: nop                      // No operation
			
			// i++
			IL_003d: ldloc.0                  // Push i
			IL_003e: ldc.i4.1                 // Push 1
			IL_003f: add                      // Pop i, pop 1, push i + 1
			IL_0040: stloc.0                  // Pop result of add, store as local 0 (i++)

			// Outer Loop Condition (i < arr.Length)
			IL_0041: ldloc.0                  // Push i
			IL_0042: ldarg.0                  // Push arr reference
			IL_0043: ldlen                    // Pop arr, push array length
			IL_0044: conv.i4                  // Convert length to signed 32-bit int
			IL_0045: clt                      // Pop length, pop i, push 1 if i < length, 0 otherwise
			IL_0047: stloc.s 6                // Pop bool result, store bool result as local 6
			IL_0049: ldloc.s 6                // Push bool result
			IL_004b: brtrue.s IL_0005         // If 1 (i < arr.Length), jump back to loop body (IL_0005), pop bool result
		// end outer loop

		IL_004d: ret                          // Return from method
	} // end of method Selsort::SelectionSort