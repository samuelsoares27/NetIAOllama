# Using Ollama in Docker

docker run -d -v ollama:/root/.ollama -p 11434:11434 --name ollama-service ollama/ollama <br/>

# Using llama3
docker exec ollama-service ollama pull llama3 <br/>

# Using gpt-oss:20b
docker exec ollama-service ollama pull gpt-oss:20b  <br/>

