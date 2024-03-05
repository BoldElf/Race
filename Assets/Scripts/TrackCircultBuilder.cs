using UnityEngine;

public static class TrackCircultBuilder 
{
    public static TrackPoint[] Build(Transform trackTransform, TrackType type)
    {
        TrackPoint[] points = new TrackPoint[trackTransform.childCount];

        ResetPoint(trackTransform, points);

        MakeLinks(type, points);

        MarkPoint(type, points);

        return points;
    }

    private static void ResetPoint(Transform trackTransform, TrackPoint[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = trackTransform.GetChild(i).GetComponent<TrackPoint>();

            if (points[i] == null)
            {
                Debug.LogError("There is no TrackPoint script on one of the child object");
                return;
            }
            points[i].ResetTrackPoint();
        }
    }
    private static void MakeLinks(TrackType type, TrackPoint[] points)
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            points[i].Next = points[i + 1];
        }

        if (type == TrackType.Circular)
        {
            points[points.Length - 1].Next = points[0];
        }
    }
    private static void MarkPoint(TrackType type, TrackPoint[] points)
    {
        points[0].IsFirst = true;

        if (type == TrackType.Sprint)
        {
            points[points.Length - 1].IsLast = true;
        }

        if (type == TrackType.Circular)
        {
            points[0].IsLast = true;
        }
    }
}
