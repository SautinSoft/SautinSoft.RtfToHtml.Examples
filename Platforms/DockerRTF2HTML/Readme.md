# Execute docker commands from project's folder

```cmd
:: 1. Create docker image named "r2himage".
docker build -t r2himage -f Dockerfile .

:: 2. Create and start docker container named "r2hcontainer".
docker run --name r2hcontainer r2himage

:: 3. Copy output files from container to project's folder.
docker cp r2hcontainer:/app/test.docx .
docker cp r2hcontainer:/app/test.html .

:: 4. Clean up, remove container and image.
docker container rm r2hcontainer
docker image rm r2himage
```