1. Build program.

2. Run program and observe result.

3. Run program again and observe different result.

4. Delete BreakProtobufNet.Payload.dll from the base directory to get the initial result again.

Somehow when the assembly containing the contract type is loaded twice protobuf-net becomes confused and (de)serializes ChildType as if it has no parent type.
