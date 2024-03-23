namespace OpenTelemetryProject;

public class OpenTelemetryService
{
    
    void metricDefinition() {
        var greeterMeter = new Meter("OtPrGrYa.Example", "1.0.0");
        var countGreetings = greeterMeter.CreateCounter<int>("greetings.count", description: "Counts the number of greetings");

        var greeterActivitySource = new ActivitySource("OtPrGrJa.Example");
    }
    
    async Task<String> SendGreeting(ILogger<Program> logger)
    {
        // Create a new Activity scoped to the method
        using var activity = greeterActivitySource.StartActivity("GreeterActivity");

        // Log a message
        logger.LogInformation("Sending greeting");

        // Increment the custom counter
        countGreetings.Add(1);

        // Add a tag to the Activity
        activity?.SetTag("greeting", "Hello World!");

        return "Hello World!";
    }

    app.MapGet("/", SendGreeting);
}