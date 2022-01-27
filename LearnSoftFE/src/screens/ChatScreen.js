import React, { useState, useCallback, useEffect } from 'react'
import { GiftedChat } from 'react-native-gifted-chat'
import { Button,TouchableOpacity, View, Text,Image,StyleSheet,Dimensions } from 'react-native';
import api from './../api/ApiCaller'
import { CurrentRenderContext } from '@react-navigation/native';

const delay = 5;

export default function ChatScreen({ route, navigation }) {

  const CurrentId = route.params.host.userId;
  const RecieverId =  route.params.user.userId;

 
  const [messages, setMessages] = useState([]);


  useEffect(() => {
    
      const intervalId = setInterval(() => { 
      api.callGetChatWithUser({"sender":CurrentId,"reciever":RecieverId})
     .then((response) => response.json())
      .then((responseJson) => {
          const mapped = responseJson.map(message =>
             (
                { _id: message.messageId,
                  createdAt: message.messageDateTime, 
                  text: message.body, 
                  user: { 
                      _id: message.senderId,
                  } 
                  }
              ));
          setMessages(mapped)
          return () =>{
            clearTimeout(timer1);
          }
      })
      .catch((error) => {
        alert(error);
      }); 
    },5000)
  return () => clearInterval(intervalId);
  })
 
  const onSend = useCallback((messages = []) => {
    const temp = messages[0]
    api.SendMessage(
      {          
        senderId: temp.user._id,
          recieverId: RecieverId,
          body: temp.text,
          messageDateTime:   new Date(),
          hasSeen: false,
        }  
     )
    setMessages(previousMessages => GiftedChat.append(previousMessages, messages))
  }, [])

  return (
     <View style={{flex: 1}}>
       <View style={{flex: 2}}>
          <GiftedChat
            bottomOffset={0}
            messages={messages}
            onSend={onSend}
            user={{
              _id: CurrentId,
            }}
            placeholder='Napisz wiadomość...'
          />
      </View>
      <View style={{flex:0.05,backgroundColor:'white'}}>

      </View>
      <View style={{flex:0.2,backgroundColor:'rgb(37, 120, 180)',flexDirection:"row"}}>
      <TouchableOpacity style={{flex:1,backgroundColor:'rgb(37, 120, 180)'}}>
       <Text style={{color:'white', justifyContent:'center',alignSelf:'center',alignContent:'center'}}>
              DODAJ ZAŁĄCZNIK
       </Text>
      </TouchableOpacity>
    <TouchableOpacity style={{flex:1,backgroundColor:'red'}}>
       <Text style={{color:'white',alignItems:'center', alignSelf:'center',alignSelf:'center',alignContent:'center'}}>
              Cofnij Wiadomość
       </Text>
      </TouchableOpacity>
      </View>
    </View>
  )
}