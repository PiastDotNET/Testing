FROM microsoft/dotnet:2.1-sdk as builder

COPY . /source/

WORKDIR /source/Piast.Api

RUN dotnet publish -o ../artifacts

FROM microsoft/dotnet:2.1-aspnetcore-runtime

COPY --from=builder /source/artifacts/. app/

ENV ASPNETCORE_URLS="http://+:5000"
ENV ASPNETCORE_ENVIRONMENT Production

WORKDIR /app

ENTRYPOINT dotnet Piast.Api.dll