using System;

// Delegate declaration
public delegate void ThresholdCrossedHandler(double temperature);

class TemperatureSensor
{
    public event ThresholdCrossedHandler? ThresholdCrossed;
    private double threshold;

    public TemperatureSensor(double threshold)
    {
        this.threshold = threshold;
    }

    public void SetTemperature(double temp)
    {
        Console.WriteLine($"Current Temperature: {temp}");
        if (temp > threshold)
        {
            // Raise the event -> notifies all subscribers
            ThresholdCrossed?.Invoke(temp);
        }
    }
}

class Program
{
    // Event handler methods (subscribers)
    static void Alarm(double temp)
    {
        Console.WriteLine($"[ALARM] Threshold crossed! Temp = {temp}");
    }

    static void LogToFile(double temp)
    {
        Console.WriteLine($"[LOG] Recording high temperature: {temp}");
    }

    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor(threshold: 40);

        // Subscribing to the event
        sensor.ThresholdCrossed += Alarm;
        sensor.ThresholdCrossed += LogToFile;

        sensor.SetTemperature(35);
        sensor.SetTemperature(45); // triggers both subscribers
    }
}
