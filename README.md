# Codespace.LLA.DataStores.Redis


Redis Stack: 

```bash
docker run -d --name redis-stack -p 6379:6379 -p 8001:8001 redis/redis-stack:latest
```

Redis Insight: Available at http://localhost:8001
CLI access: docker exec -it redis-stack redis-cli




## Redis Stack Data Storage Topics for .NET

### **Core Data Structures & Modeling**
- **Advanced data types**: RedisJSON, RedisBloom (probabilistic), RedisGraph
- **Data modeling patterns**: Document vs relational approaches
- **Schema design**: Denormalization strategies, embedding vs referencing
- **Key naming conventions** and namespace organization

### **Persistence & Durability**
- **RDB snapshots**: Configuration, backup scheduling, point-in-time recovery
- **AOF (Append-Only File)**: Write durability, log compaction
- **Hybrid persistence**: Combining RDB + AOF for optimal recovery
- **Data consistency guarantees** and trade-offs

### **Memory Management**
- **Eviction policies**: LRU, LFU, TTL-based strategies
- **Memory optimization**: Data structure selection, compression
- **Memory usage analysis** and monitoring tools
- **Lazy expiration** vs active expiration patterns

### **Transactions & Consistency**
- **MULTI/EXEC transactions**: ACID properties, rollback scenarios
- **Optimistic locking**: WATCH/UNWATCH patterns
- **Lua scripting**: Atomic operations, server-side logic
- **Pipeline operations** for batch processing

### **Data Import/Export & Migration**
- **Bulk data loading**: RESTORE, bulk insert patterns
- **Cross-instance replication** setup
- **Data serialization**: MessagePack, protobuf integration
- **Migration strategies**: Zero-downtime approaches

### **Partitioning & Scaling**
- **Hash slot distribution** in cluster mode
- **Data sharding strategies**: Consistent hashing, range-based
- **Cross-slot operations** and limitations
- **Resharding** and rebalancing

**Focus Order**: Start with advanced data types (RedisJSON), then persistence patterns, followed by memory optimization techniques.