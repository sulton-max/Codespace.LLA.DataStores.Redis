# Codespace.LLA.DataStores.Redis


Redis Stack: 

```bash
docker run -d --name redis-stack -p 6379:6379 -p 8001:8001 redis/redis-stack:latest
```

Redis Insight: Available at http://localhost:8001
CLI access: docker exec -it redis-stack redis-cli