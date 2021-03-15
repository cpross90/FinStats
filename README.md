# FinStats

C# .NET Core Web API to analyze stock and crypto data

## API

Provides a REST API for console/desktop/mobile/web clients to connect.

## Update

Listens for event updates over the Websocket API to Finnhub, parses received data, and pushes updates to the application database.

## Predict

Requests most recent for stock/market data assigned, and performs analysis to determine if a buy/sell condition exists. The application database is updated to reflect when buy/sell conditions exist. We also are interested in looking at applying some stochastic prediction algorithms as well as more straightforward statistical methods.
