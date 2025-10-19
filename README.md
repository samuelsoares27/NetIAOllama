# Using Ollama in Docker

docker run -d -v ollama:/root/.ollama -p 11434:11434 --name ollama-service ollama/ollama <br/>
docker exec ollama-service ollama pull llama3 <br/>
