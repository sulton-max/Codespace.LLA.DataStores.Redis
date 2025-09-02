# NRedisStack Overview

## Overview

NRedisStack extends StackExchange.Redis with Redis Stack modules support. Provides native .NET access to advanced Redis data structures and capabilities.

### When to Use
- JSON document storage and querying
- Full-text search and secondary indexing
- Time series data collection
- Probabilistic data structures
- Real-time analytics and aggregations

### When NOT to Use
- Simple key-value operations (use StackExchange.Redis)
- When Redis Stack modules aren't available
- Performance-critical paths requiring minimal overhead

## Core Connection

```csharp
using NRedisStack;
using StackExchange.Redis;

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
IDatabase db = redis.GetDatabase();

// Access modules
IJsonCommands json = db.JSON();
ISearchCommands ft = db.FT();
ITimeSeriesCommands ts = db.TS();
```

## Module Categories

### Document Storage & Search
- **JSON**: Document operations, path-based queries
- **Search**: Full-text search, secondary indexing, aggregations

### Probabilistic Data Structures
- **Bloom Filter**: Set membership testing
- **Cuckoo Filter**: Set membership with deletion
- **Count-min Sketch**: Frequency estimation
- **Top-K**: Top-k frequent items
- **T-Digest**: Percentile and quantile estimation

### Time Series
- **TimeSeries**: Time-based data collection and analysis

## JSON Operations

### Document Storage
- [**CRUD operations**](../src/N1_DocumentStorage/CrudOperations.cs)
- [**Object merging**](../src/Json/DocumentStorage/ObjectMerging.cs)
- [**Array manipulation**](../src/N1_DocumentStorage/ArrayOperations.cs) _Note: Array operations use string without JSON format_

- [**Memory optimization**](../src/Json/DocumentStorage/MemoryOptimization.cs)

### Document Querying
- [**Path operations**](../src/Json/DocumentQuerying/PathOperations.cs)
- [**JSONPath queries**](../src/Json/DocumentQuerying/JsonPathQueries.cs)
- [**Type operations**](../src/Json/DocumentQuerying/TypeOperations.cs)

### Document Transformation
- [**Conditional updates**](../src/Json/DocumentTransformation/ConditionalUpdates.cs)
- [**Bulk transformations**](../src/Json/DocumentTransformation/BulkTransformations.cs)
- [**Schema evolution**](../src/Json/DocumentTransformation/SchemaEvolution.cs)

## Search Operations

### Index Management
- [**Text indexing**](../src/Search/IndexManagement/TextIndexing.cs)
- [**Numeric and geo indexing**](../src/Search/IndexManagement/NumericGeoIndexing.cs)
- [**JSON indexing**](../src/Search/IndexManagement/JsonIndexing.cs)
- [**Index configuration**](../src/Search/IndexManagement/IndexConfiguration.cs)
- [**Index maintenance**](../src/Search/IndexManagement/IndexMaintenance.cs)

### Query Operations
- [**Text search**](../src/Search/QueryOperations/TextSearch.cs)
- [**Filtering and sorting**](../src/Search/QueryOperations/FilteringAndSorting.cs)
- [**Geo queries**](../src/Search/QueryOperations/GeoQueries.cs)
- [**Auto-complete**](../src/Search/QueryOperations/AutoComplete.cs)

### Analytics Operations
- [**Faceted search**](../src/Search/AnalyticsOperations/FacetedSearch.cs)
- [**Aggregations**](../src/Search/AnalyticsOperations/Aggregations.cs)
- [**Search analytics**](../src/Search/AnalyticsOperations/SearchAnalytics.cs)

## Time Series Operations

### Data Collection
- [**Create series**](../src/TimeSeries/DataCollection/CreateSeries.cs)
- [**Add samples**](../src/TimeSeries/DataCollection/AddSamples.cs)
- [**Bulk ingestion**](../src/TimeSeries/DataCollection/BulkIngestion.cs)
- [**Retention policies**](../src/TimeSeries/DataCollection/RetentionPolicies.cs)

### Data Retrieval
- [**Range queries**](../src/TimeSeries/DataRetrieval/RangeQueries.cs)
- [**Multi-series queries**](../src/TimeSeries/DataRetrieval/MultiSeriesQueries.cs)
- [**Label filtering**](../src/TimeSeries/DataRetrieval/LabelFiltering.cs)

### Data Analysis
- [**Aggregation rules**](../src/TimeSeries/DataAnalysis/AggregationRules.cs)
- [**Downsampling**](../src/TimeSeries/DataAnalysis/Downsampling.cs)
- [**Compaction**](../src/TimeSeries/DataAnalysis/Compaction.cs)
- [**Statistical functions**](../src/TimeSeries/DataAnalysis/StatisticalFunctions.cs)

## Probabilistic Data Structures

### Membership Testing
- [**Bloom filter basics**](../src/Probabilistic/MembershipTesting/BloomFilterBasics.cs)
- [**Cuckoo filter operations**](../src/Probabilistic/MembershipTesting/CuckooFilterOperations.cs)
- [**Scaling filters**](../src/Probabilistic/MembershipTesting/ScalingFilters.cs)
- [**Multi-hash functions**](../src/Probabilistic/MembershipTesting/MultiHashFunctions.cs)

### Frequency Analysis
- [**Count-min Sketch**](../src/Probabilistic/FrequencyAnalysis/CountMinSketch.cs)
- [**Top-K tracking**](../src/Probabilistic/FrequencyAnalysis/TopKTracking.cs)
- [**Heavy hitters detection**](../src/Probabilistic/FrequencyAnalysis/HeavyHittersDetection.cs)
- [**Frequency estimation**](../src/Probabilistic/FrequencyAnalysis/FrequencyEstimation.cs)

### Statistical Analysis
- [**T-Digest operations**](../src/Probabilistic/StatisticalAnalysis/TDigestOperations.cs)
- [**Percentile calculations**](../src/Probabilistic/StatisticalAnalysis/PercentileCalculations.cs)
- [**Quantile merging**](../src/Probabilistic/StatisticalAnalysis/QuantileMerging.cs)
- [**Distribution analysis**](../src/Probabilistic/StatisticalAnalysis/DistributionAnalysis.cs)

## Performance Patterns

### Connection Management
- [**Connection pooling**](../src/Performance/ConnectionManagement/ConnectionPooling.cs)
- [**Async operations**](../src/Performance/ConnectionManagement/AsyncOperations.cs)
- [**Batch processing**](../src/Performance/ConnectionManagement/BatchProcessing.cs)
- [**Pipeline operations**](../src/Performance/ConnectionManagement/PipelineOperations.cs)

### Data Optimization
- [**Memory efficiency**](../src/Performance/DataOptimization/MemoryEfficiency.cs)
- [**Serialization strategies**](../src/Performance/DataOptimization/SerializationStrategies.cs)
- [**Compression techniques**](../src/Performance/DataOptimization/CompressionTechniques.cs)

### Query Optimization
- [**Indexing strategies**](../src/Performance/QueryOptimization/IndexingStrategies.cs)
- [**Query performance**](../src/Performance/QueryOptimization/QueryPerformance.cs)
- [**Caching patterns**](../src/Performance/QueryOptimization/CachingPatterns.cs)

## Integration Patterns

### ASP.NET Core
- [**DI configuration**](../src/Integration/AspNetCore/DIConfiguration.cs)
- [**Repository pattern**](../src/Integration/AspNetCore/RepositoryPattern.cs)
- [**Caching integration**](../src/Integration/AspNetCore/CachingIntegration.cs)
- [**Health checks**](../src/Integration/AspNetCore/HealthChecks.cs)

### Microservices
- [**Service communication**](../src/Integration/Microservices/ServiceCommunication.cs)
- [**Event sourcing**](../src/Integration/Microservices/EventSourcing.cs)
- [**CQRS patterns**](../src/Integration/Microservices/CqrsPatterns.cs)
- [**Distributed caching**](../src/Integration/Microservices/DistributedCaching.cs)

## Best Practices

### ✅ DO
- Use pipelining for batch operations
- Configure appropriate index fields for search
- Set retention policies for time series data
- Use appropriate probabilistic data structure sizes
- Leverage JSON path expressions efficiently

### ❌ DON'T
- Create indexes on all JSON fields
- Store large objects in probabilistic structures
- Use time series for non-temporal data
- Mix different data access patterns in single connection
- Ignore memory implications of probabilistic structures

### Module Selection
- **JSON**: Semi-structured documents, flexible schemas
- **Search**: Text search, secondary indexing, analytics
- **TimeSeries**: Metrics, monitoring, IoT data
- **Bloom**: Large-scale deduplication, cache filtering
- **Top-K**: Real-time analytics, trending items

---

## Questions & Exercises

### JSON Operations

#### Questions
- How do JSON paths differ from object property access?
- When should you use JSON.SET vs JSON.MERGE?
- What's the performance difference between path-based vs full document operations?
- How do you handle schema evolution with JSON documents?

#### Practice Exercises
- Store user profile with nested address object
- Update specific array elements using JSON paths
- Implement conditional updates based on document state
- Create efficient document versioning system

### Search Operations

#### Questions
- What's the difference between TEXT and TAG field types?
- How do stopwords affect search performance?
- When should you use SORTBY vs scoring?
- How do aggregations work with large datasets?

#### Practice Exercises
- Index product catalog with text, numeric, and geo fields
- Implement faceted search with price ranges and categories
- Create auto-complete functionality using prefix matching
- Build analytics dashboard using search aggregations

### Time Series Operations

#### Questions
- How do retention policies affect memory usage?
- What's the difference between raw and aggregated queries?
- When should you use compaction rules?
- How do labels improve query performance?

#### Practice Exercises
- Collect application metrics with different retention periods
- Create downsampling rules for long-term storage
- Implement anomaly detection using statistical aggregations
- Build real-time dashboard with time series data

### Probabilistic Structures

#### Questions
- What's the trade-off between false positive rate and memory usage?
- How do you choose appropriate parameters for each structure?
- When is Cuckoo filter better than Bloom filter?
- How accurate are T-Digest percentile estimates?

#### Practice Exercises
- Implement cache admission policy using Bloom filters
- Track trending hashtags using Top-K structure
- Calculate response time percentiles with T-Digest
- Build frequency counter using Count-min Sketch

### Integration Scenarios

#### Questions
- How do you handle Redis Stack module availability in different environments?
- What's the migration path from StackExchange.Redis to NRedisStack?
- How do you implement fallback strategies when modules are unavailable?
- What are the implications of mixing module operations with regular Redis commands?

#### Practice Exercises
- Configure NRedisStack with ASP.NET Core DI container
- Implement repository pattern with JSON document storage
- Create event sourcing system using TimeSeries and JSON
- Build search-enabled API with pagination and filtering

### Advanced Patterns

#### Questions
- How do you combine multiple modules for complex use cases?
- What are the consistency implications of cross-module operations?
- How do you handle schema migration with indexed JSON documents?
- What's the performance impact of real-time indexing vs batch indexing?

#### Practice Exercises
- Build e-commerce search combining JSON storage and full-text search
- Implement real-time analytics using TimeSeries, JSON, and probabilistic structures
- Create recommendation engine using Top-K and Bloom filters
- Design multi-tenant system with per-tenant indexes and time series