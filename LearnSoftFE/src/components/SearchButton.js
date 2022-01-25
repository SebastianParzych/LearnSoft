
import React from 'react';
import { StyleSheet, TouchableOpacity, Text, View } from 'react-native';
 
export default function FlatButton({ text, onPress }) {
    return (
        <TouchableOpacity onPress={onPress}>
            <View style={styles.button}>
                <Text style={styles.buttonText}>{text}</Text>
            </View>
        </TouchableOpacity>
    );
}
 
const styles = StyleSheet.create({
    button: {
        flex:1,
        alignItems: 'center',
        borderRadius: 8,
        height : 20,
       // width : 150,
        paddingVertical: 14,
        paddingHorizontal: 10,
        borderWidth:2,
       borderColor:'black',
    },
    buttonText: {
        color: '#ff5c33',
        fontWeight: 'bold',
        textTransform: 'uppercase',
        fontSize: 16,
        textAlign: 'center',
    }
});