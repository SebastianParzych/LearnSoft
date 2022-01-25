import {StyleSheet, Dimensions} from 'react-native';


var {height,width} = Dimensions.get('window');


const main_style = StyleSheet.create({
  container: {
      flex:1,
      backgroundColor: '#fff',
      alignItems: 'center',
      justifyContent: 'top',

  },
    containerTop: {
      flex: 1,
      justifyContent: 'space-around',
      backgroundColor: '#fff',
      alignItems: 'center',
      justifyContent: 'center',

  },
    button :{
      alignItems: 'center',
      justifyContent: 'center',
      paddingVertical: 12,
      paddingHorizontal: 32,
      borderRadius: 4,
      elevation: 3,
      backgroundColor: 'black',
    },
  image: {
      flex: 1,
      resizeMode: 'contain',
      width: 300,
      height: 300
    },
    input:{
        borderRadius: 4,
        height: 50,
        width : 300,
        margin: 2,
        borderWidth: 2,
        padding: 10,
    },
  centralImage :{ 
      width: width*0.35,
      height: height*0.35 ,
    }
});

export default main_style;