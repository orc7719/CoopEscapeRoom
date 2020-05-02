using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class ComponentExtensions
{
    public static T CopyValues<T>(this Component comp, T source) where T:Component
    {
        return CopyValues(source, comp as T);
    }

    private static T CopyValues<T>(T source, T destination, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public ) where T : Component
    {
        if(source == null)
        {
            throw new Exception("Failed to copy object. Source is null,");
        }
        if(destination == null)
        {
            throw new Exception("Failed to copy object. Destination is null.");
        }
        Type type = source.GetType();
        var properties = type.GetProperties(flags);
        foreach (var property in properties)
        {
            if(property.CanWrite)
            {
                property.SetValue(destination, property.GetValue(source, null), null);
            }
        }
        var fields = type.GetFields(flags);
        foreach (var field in fields)
        {
            field.SetValue(destination, field.GetValue(source));
        }
        return destination;
    }
}
