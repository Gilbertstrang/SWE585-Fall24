using UnityEngine;
using Unity.Profiling;
using System.Text;

public class ProfilerRecorderController : MonoBehaviour
{
    string statsText;
    ProfilerRecorder systemMemoryRecorder;
    ProfilerRecorder gcMemoryRecorder;
    ProfilerRecorder mainThreadTimeRecorder;
    ProfilerRecorder lightingRecorder;
    ProfilerRecorder renderRecorder;

    static double GetRecorderFrameAverage(ProfilerRecorder recorder)
    {
        if (!recorder.Valid || recorder.Capacity == 0)
            return 0;

        double total = 0;
        int count = recorder.Capacity;

        foreach (var sample in recorder.ToArray())
        {
            total += sample.Value;
        }

        return total / count;
    }

    void OnEnable()
    {
        systemMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
        gcMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
        mainThreadTimeRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "Main Thread", 15);
        lightingRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Lighting, "Deferred Lighting", 15);
        renderRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Render Loop", 15);
    }

    void OnDisable()
    {
        systemMemoryRecorder.Dispose();
        gcMemoryRecorder.Dispose();
        mainThreadTimeRecorder.Dispose();
        lightingRecorder.Dispose();
        renderRecorder.Dispose();
    }

    void Update()
    {
        var sb = new StringBuilder(500);
        sb.AppendLine($"Frame Time: {GetRecorderFrameAverage(mainThreadTimeRecorder) * (1e-6f):F1} ms");
        sb.AppendLine($"GC Memory: {gcMemoryRecorder.LastValue / (1024 * 1024)} MB");
        sb.AppendLine($"System Memory: {systemMemoryRecorder.LastValue / (1024 * 1024)} MB");
        sb.AppendLine($"Lighting Time: {GetRecorderFrameAverage(lightingRecorder) * (1e-6f):F1} ms");
        sb.AppendLine($"Render Time: {GetRecorderFrameAverage(renderRecorder) * (1e-6f):F1} ms");
        statsText = sb.ToString();
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 30, 300, 200), statsText);
    }
}
